using EasyProfiler.Mongo.Statics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Events;
using System;

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
            var cacheService = serviceProvider.GetService<IMemoryCache>();
            if (command.OperationId != null)
            {
                cacheService.Set<string>(command.OperationId + command.CommandName, command.Command.ToString(), new MemoryCacheEntryOptions
                {
                    Priority = CacheItemPriority.NeverRemove
                });
            }
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
            var cacheService = serviceProvider.GetService<IMemoryCache>();
            var httpContext = serviceProvider.GetService<IHttpContextAccessor>();
            var data = cacheService.Get<string>(command.OperationId + command.CommandName);
            cacheService.Remove(command.OperationId + command.CommandName);
            if (data != null)
            {
                MongoValues.Profilers.Add(new Models.Profiler
                {
                    Duration = command.Duration.Ticks,
                    Query = data.ToString(),
                    QueryType = command.CommandName.FindQueryType(),
                    RequestUrl = httpContext.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint?.DisplayName ?? "Not Http",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow - command.Duration
                });
            }
        }
    }
}
