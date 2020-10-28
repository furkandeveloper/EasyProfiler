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
using EasyProfiler.Core.Abstractions;

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
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(services.BuildServiceProvider().GetService<IEasyProfilerBaseService<ProfilerDbContext>>()));
            return optionsBuilder;
        }
    }
}
