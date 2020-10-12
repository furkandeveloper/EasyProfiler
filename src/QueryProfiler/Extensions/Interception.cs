using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using QueryProfiler.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QueryProfiler.Extensions
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
        public static DbContextOptionsBuilder AddEasyProfiler(this DbContextOptionsBuilder optionsBuilder)
        {
            var interceptors = typeof(ProfilerDbContext).Assembly.GetTypes().Where(x => typeof(DbCommandInterceptor).IsAssignableFrom(x) && x!= typeof(DbConnectionInterceptor) && x.IsClass) as IEnumerable<IInterceptor>;
            optionsBuilder.AddInterceptors(interceptors);
            return optionsBuilder;
        }
    }
}
