using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using EasyProfiler.EntityFrameworkCore;

namespace EasyProfiler.PostgreSQL.Context
{
    /// <summary>
    /// Design time db context for migrations.
    /// </summary>
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerPostgreSqlDbContext>
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
        public ProfilerPostgreSqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerPostgreSqlDbContext>();
            optionsBuilder.UseNpgsql("xxxx");
            return new ProfilerPostgreSqlDbContext(optionsBuilder.Options);
        }
    }
}
