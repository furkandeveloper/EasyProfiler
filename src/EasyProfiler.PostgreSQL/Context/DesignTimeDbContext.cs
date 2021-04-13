using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.PostgreSQL.Context
{
    /// <summary>
    /// Design time db context for migrations.
    /// </summary>
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        /// <summary>
        /// Create DbContext instance.
        /// </summary>
        /// <param name="args">
        /// argumerts.
        /// </param>
        /// <returns>
        /// DbContext.
        /// </returns>
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
            optionsBuilder.UseNpgsql("xxxx");
            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
