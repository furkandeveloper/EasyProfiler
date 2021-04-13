using EasyCache.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.CronJob.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.PostgreSQL.BackgroundJobs
{
    public class DbWriterCronJob : CronJobService
    {
        //private readonly IEasyCacheService easyCacheService;
        private readonly IMemoryCache cache;

        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration/*, IEasyCacheService easyCacheService,*/, IMemoryCache cache)
            : base(configuration.CronExpression, configuration.TimeZoneInfo)
        {
            //this.easyCacheService = easyCacheService;
            this.cache = cache;
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            //var cachedValue = easyCacheService.Get<Profiler>("easy-profiler");
            var cachedValue = cache.Get("test");
            return base.DoWork(cancellationToken);
        }
    }
}
