using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Statics;
using EasyProfiler.CronJob.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.PostgreSQL.BackgroundJobs
{
    public class DbWriterCronJob : CronJobService
    {
        private readonly ProfilerPostgreSqlDbContext profilerPostgreSqlDbContext;

        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration, ProfilerPostgreSqlDbContext profilerPostgreSqlDbContext)
            : base(configuration.CronExpression, configuration.TimeZoneInfo)
        {
            this.profilerPostgreSqlDbContext = profilerPostgreSqlDbContext;
        }

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
                await profilerPostgreSqlDbContext.InsertAsync(profiler);
            await base.DoWork(cancellationToken);
        }
    }
}
