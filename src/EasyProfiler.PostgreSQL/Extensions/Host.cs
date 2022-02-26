using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace EasyProfiler.PostgreSQL.Extensions
{
    /// <summary>
    /// This class includes <see cref="IHost"/> extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class Host
    {
        /// <summary>
        /// This method provides database migration for PostgreSql. 
        /// </summary>
        /// <param name="host">
        /// <see cref="IHost"/>
        /// </param>
        /// <returns>
        /// Returns a <see cref="IHost"/>
        /// </returns>
        public static IHost MigrateEasyProfiler(this IHost host)
        {
            using var serviceScope = host.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ProfilerPostgreSqlDbContext>();
            var pendingMigrations = context.Database.GetPendingMigrations().ToArray();
            if (pendingMigrations.Length > 0)
            {
                context.Database.Migrate();
            }
            else
            {
                context.Database.EnsureCreated();
            }

            return host;
        }
    }
}
