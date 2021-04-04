using EasyProfiler.CronJob.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.CronJob.Concrete
{
    public class DbWriterCronJob : CronJobService
    {
        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration)
            :base(configuration.CronExpression, configuration.TimeZoneInfo)
        {

        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            return base.DoWork(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
