using EasyCache.Services.Abstractions;
using EasyProfiler.Mongo.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Extensions
{
    /// <summary>
    /// This extension includes interceptors for Mongo.
    /// </summary>
    public static class ClusterBuilderExtensions
    {
        /// <summary>
        /// Command Started Event interceptor
        /// </summary>
        /// <param name="command">
        /// Command Started event
        /// </param>
        /// <param name="serviceProvider">
        /// IServiceProvider
        /// </param>
        public static void InitilazeStartedEvent(this CommandStartedEvent command, IServiceProvider serviceProvider)
        {
            var cacheService = serviceProvider.GetService<ICacheService>();
            if (command.OperationId != null)
                cacheService.Set<string>(command.OperationId + command.CommandName, command.Command.ToString(), TimeSpan.FromMinutes(5));
        }

        /// <summary>
        /// Command Succeeded Event interceptor
        /// </summary>
        /// <param name="command">
        /// Command Succeeded event
        /// </param>
        /// <param name="serviceProvider">
        /// IServiceProvider
        /// </param>
        public static void InitilazeSucceededEvent(this CommandSucceededEvent command, IServiceProvider serviceProvider)
        {
            var cacheService = serviceProvider.GetService<ICacheService>();
            var mongoService = serviceProvider.GetService<IMongoService>();
            var httpContext = serviceProvider.GetService<IHttpContextAccessor>();
            var data = cacheService.Get<string>(command.OperationId + command.CommandName);
            if (data != null)
            {
                mongoService.InsertAsync(new Models.Profiler()
                {
                    Duration = command.Duration.Ticks,
                    Query = data.ToString(),
                    QueryType = command.CommandName.FindQueryType(),
                    RequestUrl = httpContext?.HttpContext?.Request?.Path.Value
                });
            }
        }
    }
}
