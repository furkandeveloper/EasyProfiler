using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.EntityFrameworkCore;

namespace EasyProfiler.SQLServer.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    public class ProfilerSqlServerDbContext : ProfilerCoreDbContext, IEasyProfilerContext
    {
        public ProfilerSqlServerDbContext(DbContextOptions<ProfilerSqlServerDbContext> options) : base(options)
        {
        }

        protected ProfilerSqlServerDbContext()
        {
        }
    }
}
