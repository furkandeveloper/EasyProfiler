using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueryProfiler.Entities;
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
        #region Tables
        public virtual DbSet<Profiler> Profilers { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
