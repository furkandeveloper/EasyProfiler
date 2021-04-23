using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Statics;
using EasyProfiler.CronJob.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.CronJob.Jobs
{
    /// <summary>
    /// Database Writer Cron Job
    /// </summary>
    public class DbWriterCronJob : CronJobService
    {
        /// <summary>
        /// Profiler Db Context
        /// </summary>
        private readonly IEasyProfilerContext profilerContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">
        /// ICronConfiguration Object for DbWriterCronJob
        /// </param>
        /// <param name="profilerContext">
        /// Profiler Db Context
        /// </param>
        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration, IEasyProfilerContext profilerContext)
            : base(configuration.CronExpression, configuration.TimeZoneInfo)
        {
            this.profilerContext = profilerContext;
        }

        /// <summary>
        /// DoWork section of Cron Job
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that operations should be canceled.
        /// </param>
        public override async Task DoWork(CancellationToken cancellationToken)
        {
            var profilerData = Values.Profilers.Select(s => new Profiler
            {
                Duration = s.Duration,
                Id = s.Id,
                QueryType = s.QueryType,
                RequestUrl = s.RequestUrl,
                Query = s.Query,
            }).ToList();
            Values.Profilers.Clear();
            foreach (var profiler in profilerData)
                await profilerContext.InsertAsync(profiler);
            await base.DoWork(cancellationToken);
        }
    }
}
