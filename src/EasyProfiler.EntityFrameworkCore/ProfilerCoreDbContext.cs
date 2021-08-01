using System.Linq;
using System.Threading.Tasks;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using EasyProfiler.EntityFrameworkCore.Generators;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyProfiler.EntityFrameworkCore
{
    public abstract class ProfilerCoreDbContext : DbContext, IEasyProfilerContext
    {
        protected ProfilerCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ProfilerCoreDbContext()
        {
        }
        
        #region Tables
        public virtual DbSet<Profiler> Profilers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Profiler>(entity =>
            {
                entity
                    .ToTable(nameof(Profilers), "easy-profiler");

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
                    .HasConversion(new EnumToStringConverter<QueryType>());
                
                entity
                    .Property(p => p.Duration)
                    .HasColumnType("bigint");
            });
        }

        public IQueryable<T> Get<T>()
            where T:class
        {
            return Set<T>().AsQueryable();
        }

        public async Task InsertAsync<T>(T entity)
            where  T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
        }
    }
}