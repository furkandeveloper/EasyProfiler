using System.Linq;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.MariaDb.Context;
using EasyProfiler.MariaDb.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.MariaDb.Extensions
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
            var buildServices = services.BuildServiceProvider();
            optionsBuilder.AddInterceptors(
                new EasyProfilerInterceptors(
                    buildServices.GetService<IHttpContextAccessor>()));
            return optionsBuilder;
        }
    }
}
