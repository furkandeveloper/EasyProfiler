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
    public static class CronJobServiceExtensions
    {
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
