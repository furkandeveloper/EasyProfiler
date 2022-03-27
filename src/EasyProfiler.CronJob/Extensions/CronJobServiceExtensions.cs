using EasyProfiler.Core.Exceptions;
using EasyProfiler.CronJob.Abstractions;
using EasyProfiler.CronJob.Common;
using EasyProfiler.CronJob.Jobs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

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

        public static IServiceCollection ToResulation(this IServiceCollection services, Action<DbResulationConfiguration> resulationConfiguration)
        {
            DbResulationConfiguration dbResulationConfiguration = new DbResulationConfiguration();
            resulationConfiguration.Invoke(dbResulationConfiguration);
            if (dbResulationConfiguration.UseCronExpression)
            {
                var data = Cronos.CronExpression.Parse(dbResulationConfiguration.CronExpression);
                var nextDate = data.GetNextOccurrence(DateTime.UtcNow, TimeZoneInfo.Local);
                if ((nextDate - DateTime.UtcNow).Value.TotalHours > 1)
                {
                    throw new BaseException("Cron expression cannot be greater than 1 hour.");
                }
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.CronExpression;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            }
            else
            {
                services.ApplyResulation<DbWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.Resulation.GetType().GetField(dbResulationConfiguration.Resulation.ToString()).GetCustomAttribute<ResulationCronAttribute>().Cron;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            }
            return services;
        }
    }
}
