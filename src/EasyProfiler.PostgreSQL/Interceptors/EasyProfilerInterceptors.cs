using EasyProfiler.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Data.Common;
using EasyProfiler.EntityFrameworkCore.Extensions;
using System;

namespace EasyProfiler.PostgreSQL.Interceptors
{
    /// <summary>
    /// Profiler Interceptors.
    /// </summary>
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMemoryCache memoryCache;
        private readonly IProfilerCache profilerCache;

        public EasyProfilerInterceptors(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, IProfilerCache profilerCache)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.memoryCache = memoryCache;
            this.profilerCache = profilerCache;
        }
        /// <summary>
        /// Data reader Disposing.
        /// </summary>
        /// <param name="command">
        /// DbCommand.
        /// </param>
        /// <param name="eventData">
        /// Event data.
        /// </param>
        /// <param name="result">
        /// Interception result.
        /// </param>
        /// <returns></returns>
        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            var profilerData = new Profiler
            {
                Duration = eventData.Duration.Ticks,
                Query = command.CommandText,
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
                QueryType = command.FindQueryType()
            };

            var cachedData = memoryCache.Get<List<Profiler>>("easy-profiler") ?? new List<Profiler>();
            cachedData.Add(profilerData);
            memoryCache.Set("easy-profiler", cachedData, TimeSpan.FromDays(1));
            memoryCache.Set<string>("test", "test-furkan", TimeSpan.FromDays(1));

            profilerCache.Set("easy-profiler", cachedData, TimeSpan.FromDays(1));
            profilerCache.Set<string>("test", "test-furkan", TimeSpan.FromDays(1));
            var data = profilerCache.Get<string>("test");

            //cachedValue.Add(new Profiler
            //{
            //    Duration = eventData.Duration.Ticks,
            //    Query = command.CommandText,
            //    RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
            //    QueryType = command.FindQueryType()
            //});
            //easyCacheService.Set<List<Profiler>>("easy-profiler", cachedValue, TimeSpan.FromMinutes(2));
            //var data = easyCacheService.Get<List<Profiler>>("easy-profiler");
            //var cachedValue = easyCacheService.GetAndSet("easy-profiler",()=> new List<Profiler> { new Profiler { Query = "Ahmet"} },TimeSpan.FromSeconds(100));
            //var data = easyCacheService.Get<List<Profiler>>("easy-profiler");
            //easyCacheService.GetAndSet("test", () => "12", TimeSpan.FromSeconds(100));
            //var data = easyCacheService.Get<string>("test");
            //cachedValue=new Profiler
            //{
            //    Duration = eventData.Duration.Ticks,
            //    Query = command.CommandText,
            //    RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
            //    QueryType = command.FindQueryType()
            //};
            //easyCacheService.SetAsync("easy-profiler", cachedValue, TimeSpan.FromMinutes(5)).ConfigureAwait(false);
            //Task.Run(() => baseService.InsertAsync(new Profiler
            //{
            //    Duration = eventData.Duration.Ticks,
            //    Query = command.CommandText,
            //    RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
            //    QueryType = command.FindQueryType()
            //}));
            return base.DataReaderDisposing(command, eventData, result);
        }

        private Profiler GetData()
        {
            return new Profiler
            {
                Query = "Zalım",
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
            };
        }
    }
}
