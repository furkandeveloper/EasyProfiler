using EasyCache.Core.Abstractions;
using EasyCache.Core.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EasyProfiler.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.PostgreSQL.Interceptors
{
    /// <summary>
    /// Profiler Interceptors.
    /// </summary>
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IEasyCacheService easyCacheService;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService, IHttpContextAccessor httpContextAccessor, IEasyCacheService easyCacheService)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.easyCacheService = easyCacheService;
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
            //var cachedValue = easyCacheService.GetAndSet<Profiler>("easy-profiler", () => GetData(), TimeSpan.FromMinutes(2));
            var cache = httpContextAccessor.HttpContext.RequestServices.GetService<IMemoryCache>();
            cache.Set("test", "string", TimeSpan.FromMinutes(20));

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
