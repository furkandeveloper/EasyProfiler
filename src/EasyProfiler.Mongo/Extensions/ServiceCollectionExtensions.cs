using EasyProfiler.Mongo.Configuration;
using EasyProfiler.Mongo.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.CronJob.Common;
using EasyProfiler.CronJob.Extensions;
using EasyProfiler.Mongo.Jobs;
using System.Reflection;

namespace EasyProfiler.Mongo.Extensions
{
    /// <summary>
    /// This extension includes initilaze database connection model.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Initilaze Dbcontext configuration.
        /// </summary>
        /// <param name="services">
        /// Service collection
        /// </param>
        /// <param name="configuration">
        /// Database connection object
        /// </param>
        /// <returns>
        /// IServiceCollection
        /// </returns>
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<ConnectionModel> configuration, Action<DbResulationConfiguration> resulationConfiguration)
        {
            ConnectionModel connectionModel = new ConnectionModel();
            configuration.Invoke(connectionModel);
            services.AddSingleton(connectionModel);
            services.AddMemoryCache();
            services.AddSingleton<IEasyProfilerContext, EasyProfilerMongoDbContext>();
            services = services.ToResulation(resulationConfiguration);
            return services;
        }

        private static IServiceCollection ToResulation(this IServiceCollection services, Action<DbResulationConfiguration> resulationConfiguration)
        {
            DbResulationConfiguration dbResulationConfiguration = new DbResulationConfiguration();
            resulationConfiguration.Invoke(dbResulationConfiguration);
            if (dbResulationConfiguration.UseCronExpression)
            {
                var data = Cronos.CronExpression.Parse(dbResulationConfiguration.CronExpression);
                var nextDate = data.GetNextOccurrence(DateTime.UtcNow, TimeZoneInfo.Local);
                if ((nextDate - DateTime.UtcNow).Value.TotalHours > 1)
                    throw new Exception("Cron expression cannot be greater than 1 hour.");
                services.ApplyResulation<MongoWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.CronExpression;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            }
            else
                services.ApplyResulation<MongoWriterCronJob>(options =>
                {
                    options.CronExpression = dbResulationConfiguration.Resulation.GetType().GetField(dbResulationConfiguration.Resulation.ToString()).GetCustomAttribute<ResulationCronAttribute>().Cron;
                    options.TimeZoneInfo = dbResulationConfiguration.TimeZoneInfo;
                });
            return services;
        }
    }
}
