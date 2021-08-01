using EasyProfiler.Core.Abstractions;
using EasyProfiler.CronJob.Abstractions;
using EasyProfiler.Mongo.Models;
using EasyProfiler.Mongo.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.Mongo.Jobs
{
    public class MongoWriterCronJob : CronJobService
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
        public MongoWriterCronJob(ICronConfiguration<MongoWriterCronJob> configuration, IEasyProfilerContext profilerContext)
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
            var profilerData = MongoValues.Profilers.Select(s => new Profiler
            {
                Duration = s.Duration,
                Id = s.Id,
                QueryType = s.QueryType,
                RequestUrl = s.RequestUrl,
                Query = s.Query,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }).ToList();
            MongoValues.Profilers.Clear();
            foreach (var profiler in profilerData)
            {
                await profilerContext.InsertAsync(profiler);
            }
            await base.DoWork(cancellationToken);
        }
    }
}
