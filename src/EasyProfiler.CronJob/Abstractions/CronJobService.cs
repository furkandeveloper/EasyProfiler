using Cronos;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.CronJob.Abstractions
{
    /// <summary>
    /// This class includes base operations for Cron Job
    /// </summary>
    public abstract class CronJobService : IHostedService, IDisposable
    {
        private System.Timers.Timer timer; 
        private readonly TimeZoneInfo timeZoneInfo;
        private readonly CronExpression cronExpression;
        protected CronJobService(string cronExpression, TimeZoneInfo timeZoneInfo)
        {
            this.timeZoneInfo = timeZoneInfo;
            this.cronExpression = CronExpression.Parse(cronExpression);
        }

        protected virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {
            var next = cronExpression.GetNextOccurrence(DateTimeOffset.Now, timeZoneInfo);
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)   // prevent non-positive values from being passed into Timer
                {
                    await ScheduleJob(cancellationToken);
                }
                timer = new System.Timers.Timer(delay.TotalMilliseconds);
                timer.Elapsed += async (sender, args) =>
                {
                    timer.Dispose();  // reset and dispose timer
                    timer = null;

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await DoWork(cancellationToken);
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await ScheduleJob(cancellationToken);    // reschedule next
                    }
                };
                timer.Start();
            }
            await Task.CompletedTask;
        }

        public virtual async Task DoWork(CancellationToken cancellationToken)
        {
            await Task.Delay(50, cancellationToken);  // do the work
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await ScheduleJob(cancellationToken);
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Stop();
            await Task.CompletedTask;
        }
    }
}
