using EasyProfiler.PostgreSQL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

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
        public static IApplicationBuilder ApplyEasyProfilerPostgreSQL(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<ProfilerPostgreSqlDbContext>().Database.Migrate();
            return app;
        }
    }
}
