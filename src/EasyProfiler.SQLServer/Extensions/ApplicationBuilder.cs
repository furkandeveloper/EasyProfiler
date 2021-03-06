﻿using EasyProfiler.SQLServer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.SQLServer.Extensions
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
        /// <param name="sqlServerDbContext">
        /// Profiler DbContext
        /// </param>
        public static IApplicationBuilder ApplyEasyProfilerSQLServer(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<ProfilerSqlServerDbContext>().Database.Migrate();
            return app;
        }
    }
}
