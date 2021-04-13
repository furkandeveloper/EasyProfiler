using EasyCache.Memory.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Concrete;
using EasyProfiler.CronJob.Common;
using EasyProfiler.CronJob.Concrete;
using EasyProfiler.CronJob.Extensions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyProfiler.PostgreSQL.Extensions
{
    public static class ServiceCollection
    {
        /// <summary>
        /// Add DbContext for EasyProfiler.
        /// </summary>
        /// <param name="services">
        /// Service collection.
        /// </param>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder.
        /// </param>
        /// <returns>
        /// Service Collection.
        /// </returns>
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder,
            Action<DbResulationConfiguration> dbResulationConfiguration)
        {
            services.AddDbContext<ProfilerDbContext>(optionsBuilder);
            services.AddTransient<IEasyProfilerBaseService<ProfilerDbContext>, EasyProfilerBaseManager<ProfilerDbContext>>();
            services.AddEasyMemoryCache();
            DbResulationConfiguration resulationConfiguration = new DbResulationConfiguration();
            dbResulationConfiguration.Invoke(resulationConfiguration);
            if (resulationConfiguration.UseCronExpression)
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = resulationConfiguration.CronExpression;
                    options.TimeZoneInfo = resulationConfiguration.TimeZoneInfo;
                });
            else
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = typeof(Resulation).GetField(resulationConfiguration.Resulation.ToString()).GetCustomAttribute<ResulationCronAttribute>().Cron;
                    options.TimeZoneInfo = resulationConfiguration.TimeZoneInfo;
                });
            return services;
        }
    }
}
