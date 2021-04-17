using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.CronJob.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.PostgreSQL.BackgroundJobs
{
    public class DbWriterCronJob : CronJobService
    {
        private readonly IMemoryCache cache;
        private readonly ProfilerPostgreSqlDbContext profilerPostgreSqlDbContext;
        private readonly IProfilerCache profilerCache;

        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration, IMemoryCache cache, ProfilerPostgreSqlDbContext profilerPostgreSqlDbContext, IProfilerCache profilerCache)
            : base(configuration.CronExpression, configuration.TimeZoneInfo)
        {
            this.cache = cache;
            this.profilerPostgreSqlDbContext = profilerPostgreSqlDbContext;
            this.profilerCache = profilerCache;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            var cachedValue = profilerCache.Get<List<Profiler>>("easy-profiler") ?? new List<Profiler>();
            var test = profilerCache.Get<string>("test");
            //profilerCache.Remove("easy-profiler");
            foreach (var value in cachedValue)
            {
                await profilerPostgreSqlDbContext.InsertAsync(value);
            }
            await base.DoWork(cancellationToken);
        }
    }
}
