using System;
using EasyProfiler.MariaDb.Abstractions;
using EasyProfiler.MariaDb.Concrete;
using EasyProfiler.MariaDb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.MariaDb.Extensions
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
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
        {
            services.AddDbContext<ProfilerDbContext>(optionsBuilder);
            services.AddTransient<IEasyProfilerService, EasyProfilerManager>();
            return services;
        }
    }
}