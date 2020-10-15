using EasyProfiler.SQLServer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyProfiler.SQLServer.Extensions
{
    public static class ApplicationBuilder
    {
        public static IApplicationBuilder ApplyEasyProfilerSQLServer(this IApplicationBuilder app, ProfilerDbContext dbContext)
        {
            dbContext.Database.Migrate();
            return app;
        }
    }
}
