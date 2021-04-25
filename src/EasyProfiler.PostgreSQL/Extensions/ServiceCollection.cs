using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Concrete;
using EasyProfiler.CronJob.Common;
using EasyProfiler.CronJob.Extensions;
using EasyProfiler.CronJob.Jobs;
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
            services.AddDbContext<ProfilerPostgreSqlDbContext>(optionsBuilder, ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IEasyProfilerContext>(sp => sp.GetService<ProfilerPostgreSqlDbContext>());
            services.AddTransient<IEasyProfilerBaseService<ProfilerPostgreSqlDbContext>, EasyProfilerBaseManager<ProfilerPostgreSqlDbContext>>();
            services = services.ToResulation(resulationConfiguration);
            return services;
        }
    }
}
