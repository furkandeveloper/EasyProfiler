using EasyProfiler.Core.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using EasyProfiler.PostgreSQL.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.PostgreSQL.Extensions
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
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(services.BuildServiceProvider().GetService<IEasyProfilerBaseService<ProfilerDbContext>>()));
            return optionsBuilder;
        }
    }
}
