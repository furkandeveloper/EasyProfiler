using EasyProfiler.CronJob.Abstractions;
using EasyProfiler.CronJob.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Extensions
{
    /// <summary>
    /// Cron Job Service Collection Extensions
    /// </summary>
    public static class CronJobServiceExtensions
    {
        /// <summary>
        /// Apply Resulation
        /// </summary>
        /// <typeparam name="T">
        /// Cron Job Service in CronJobService type
        /// </typeparam>
        /// <param name="services">
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </param>
        /// <param name="action">
        /// Cron Configuration Action Object
        /// </param>
        /// <returns>
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </returns>
        public static IServiceCollection ApplyResulation<T>(this IServiceCollection services, Action<ICronConfiguration<T>> action)
            where T : CronJobService
        {
            var options = new CronConfiguration<T>();
            action.Invoke(options);
            services.AddSingleton<ICronConfiguration<T>>(options);
            services.AddHostedService<T>();
            return services;
        }
    }
}
