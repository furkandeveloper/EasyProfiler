using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Web
{
    /// <summary>
    /// Sample Db Context
    /// </summary>
    public class SampleDbContext : DbContext
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="options">
        /// DbContextOptions
        /// </param>
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        protected SampleDbContext()
        {
        }
        /// <summary>
        /// Customer Table
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">
        /// Summary:
        ///     Provides a simple API surface for configuring a Microsoft.EntityFrameworkCore.Metadata.IMutableModel
        ///     that defines the shape of your entities, the relationships between them, and
        ///     how they map to the database.
        ///     You can use Microsoft.EntityFrameworkCore.ModelBuilder to construct a model for
        ///     a context by overriding Microsoft.EntityFrameworkCore.DbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)
        ///     on your derived context. Alternatively you can create the model externally and
        ///     set it on a Microsoft.EntityFrameworkCore.DbContextOptions instance that is passed
        ///     to the context constructor.
        /// </param>
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
