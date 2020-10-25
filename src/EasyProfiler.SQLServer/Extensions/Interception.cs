using EasyProfiler.SQLServer.Context;
using EasyProfiler.SQLServer.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using EasyProfiler.SQLServer.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EasyProfiler.SQLServer.Extensions
{
    /// <summary>
    /// Interception extension method for dbcontext.
    /// </summary>
    public static class Interception
    {
        /// <summary>
        /// Add easy profiler for interceptions.
        /// </summary>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder
        /// </param>
        /// <returns>
        /// DbContextOptionsBuilder.
        /// </returns>
        public static DbContextOptionsBuilder AddEasyProfiler(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var interceptors = typeof(ProfilerDbContext).Assembly.GetTypes().Where(x => typeof(DbCommandInterceptor).IsAssignableFrom(x) && x != typeof(DbConnectionInterceptor) && x.IsClass).ToList();
            //foreach (var interceptor in interceptors)
            //{
            //    optionsBuilder.AddInterceptors(interceptor);
            //}
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(services.BuildServiceProvider().GetService<IEasyProfilerService>()));
            
            return optionsBuilder;
        }
    }
}
