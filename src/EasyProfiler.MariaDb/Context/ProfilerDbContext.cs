using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyProfiler.MariaDb.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    public class ProfilerDbContext : DbContext
    {
        public ProfilerDbContext(DbContextOptions<ProfilerDbContext> options) : base(options)
        {
        }

        public ProfilerDbContext()
        {
        }
        #region Tables
        public virtual DbSet<Profiler> Profilers { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profiler>(entity =>
            {
                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(i => i.Duration);

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Query)
                    .IsRequired();

                entity
                    .Property(p => p.QueryType)
                    .IsRequired()
                    .HasConversion(new EnumToStringConverter<QueryType>());

                entity
                    .Property(p => p.Duration)
                    .HasColumnType("bigint");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
