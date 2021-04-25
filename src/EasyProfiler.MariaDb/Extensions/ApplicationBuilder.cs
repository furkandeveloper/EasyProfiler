using EasyProfiler.MariaDb.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.MariaDb.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilder
    {
        /// <summary>
        /// Database migration for SQL Server.
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        /// <param name="mariaDbContext">
        /// Profiler DbContext
        /// </param>
        public static IApplicationBuilder ApplyEasyProfilerMariaDb(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<ProfilerMariaDbContext>().Database.Migrate();
            return app;
        }
    }
}
