using EasyProfiler.SQLite.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace EasyProfiler.SQLite.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilder
    {
        /// <summary>
        /// Database migration for SQLite.
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        /// <param name="dbContext">
        /// Profiler DbContext
        /// </param>
        public static void ApplyEasyProfilerSQLite(this IApplicationBuilder app, ProfilerDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }
    }
}
