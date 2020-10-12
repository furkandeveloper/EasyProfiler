using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    internal class ProfilerDbContext : DbContext
    {
        internal ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        internal ProfilerDbContext()
        {
        }
    }
}
