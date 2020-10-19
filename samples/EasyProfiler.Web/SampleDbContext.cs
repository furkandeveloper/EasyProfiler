using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Web
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected SampleDbContext()
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .Property(p => p.CustomerId)
                    .UseIdentityColumn();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
