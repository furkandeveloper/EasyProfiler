using EasyProfiler.Mongo.Configuration;
using EasyProfiler.Mongo.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EasyProfiler.Core.Abstractions;

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
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<ConnectionModel> configuration)
        {
            ConnectionModel connectionModel = new ConnectionModel();
            configuration.Invoke(connectionModel);
            services.AddSingleton(connectionModel);
            services.AddMemoryCache();
            services.AddSingleton<IEasyProfilerContext, EasyProfilerMongoDbContext>();
            return services;
        }
    }
}
