using EasyCache.Memory.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Concrete;
using EasyProfiler.CronJob.Common;
using EasyProfiler.CronJob.Extensions;
using EasyProfiler.PostgreSQL.BackgroundJobs;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

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
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder, Action<DbResulationConfiguration> resulationConfiguration)
        {
            services.AddDbContext<ProfilerDbContext>(optionsBuilder, ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IEasyProfilerBaseService<ProfilerDbContext>, EasyProfilerBaseManager<ProfilerDbContext>>();
            //services.AddEasyMemoryCache();
            services.AddMemoryCache();
            DbResulationConfiguration dbResulationConfiguration = new DbResulationConfiguration();
            resulationConfiguration.Invoke(dbResulationConfiguration);
            if (dbResulationConfiguration.UseCronExpression)
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.CronExpression;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            else
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.Resulation.GetType().GetField(dbResulationConfiguration.Resulation.ToString()).GetCustomAttribute<ResulationCronAttribute>().Cron;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            return services;
        }
    }
}
