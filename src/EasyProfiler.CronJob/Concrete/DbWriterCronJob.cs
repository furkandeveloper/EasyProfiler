using EasyCache.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.CronJob.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyProfiler.CronJob.Concrete
{
    public class DbWriterCronJob : CronJobService
    {
        private readonly IEasyCacheService easyCacheService;

        public DbWriterCronJob(ICronConfiguration<DbWriterCronJob> configuration, IEasyCacheService easyCacheService)
            :base(configuration.CronExpression, configuration.TimeZoneInfo)
        {
            this.easyCacheService = easyCacheService;
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            var cachedValue = easyCacheService.Get<List<Profiler>>("easy-profiler");
            return base.DoWork(cancellationToken);
        }
    }
}
