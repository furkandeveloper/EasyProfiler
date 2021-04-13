using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Concrete;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.PostgreSQL.Extensions
{
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
            services.AddDbContext<ProfilerPostgreSqlDbContext>(optionsBuilder);
            services.AddTransient<IEasyProfilerContext>(sp => sp.GetService<ProfilerPostgreSqlDbContext>());
            services.AddTransient<IEasyProfilerBaseService<ProfilerPostgreSqlDbContext>, EasyProfilerBaseManager<ProfilerPostgreSqlDbContext>>();
            return services;
        }
    }
}
