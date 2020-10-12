using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QueryProfiler.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Extensions
{
    /// <summary>
    /// Service collection extensions method for DbContext.
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Add DbContext for EasyProfiler.
        /// </summary>
        /// <param name="services">
        /// Service collection.
        /// </param>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder.
        /// </param>
        /// <returns>
        /// Service Collection.
        /// </returns>
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services,Action<DbContextOptionsBuilder> optionsBuilder)
        {
            services.AddDbContext<ProfilerDbContext>(optionsBuilder);
            return services;
        }
    }
}
