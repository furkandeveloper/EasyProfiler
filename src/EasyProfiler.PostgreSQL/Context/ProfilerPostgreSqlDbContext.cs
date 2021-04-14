using EasyProfiler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using EasyProfiler.EntityFrameworkCore;

namespace EasyProfiler.PostgreSQL.Context
{
    /// <summary>
    /// Profiler DbContext for PostgreSQL
    /// </summary>
    public class ProfilerPostgreSqlDbContext : ProfilerCoreDbContext
    {
        public ProfilerPostgreSqlDbContext(DbContextOptions<ProfilerPostgreSqlDbContext> options) : base(options)
        {
        }

        protected ProfilerPostgreSqlDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profiler>(entity =>
            {
                entity
                    .Property(p => p.Duration)
                    .HasColumnType("bigint");
            });
        }
    }
}
