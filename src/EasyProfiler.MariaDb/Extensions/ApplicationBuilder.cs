using EasyProfiler.MariaDb.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

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
        /// <param name="dbContext">
        /// Profiler DbContext
        /// </param>
        public static void ApplyEasyProfilerSQLServer(this IApplicationBuilder app, ProfilerDbContext dbContext)
        {
            var migrations = dbContext.Database.GetPendingMigrations();
            dbContext.Database.Migrate();
        }
    }
}
