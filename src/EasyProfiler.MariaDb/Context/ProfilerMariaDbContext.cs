using EasyProfiler.Core.Entities;
using EasyProfiler.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyProfiler.MariaDb.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    public class ProfilerMariaDbContext : ProfilerCoreDbContext
    {
        public ProfilerMariaDbContext(DbContextOptions<ProfilerMariaDbContext> options) : base(options)
        {
        }

        protected ProfilerMariaDbContext()
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
