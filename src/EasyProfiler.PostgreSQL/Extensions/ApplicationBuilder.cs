using EasyProfiler.PostgreSQL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.PostgreSQL.Extensions
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
        /// <param name="postgreSqlDbContext">
        /// Profiler DbContext
        /// </param>
        public static void ApplyEasyProfilerPostgreSQL(this IApplicationBuilder app, ProfilerPostgreSqlDbContext postgreSqlDbContext)
        {
            postgreSqlDbContext.Database.Migrate();
        }
    }
}
