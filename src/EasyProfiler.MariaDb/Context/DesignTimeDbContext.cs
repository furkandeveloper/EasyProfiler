using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyProfiler.MariaDb.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
#if NETCOREAPP3_1
            optionsBuilder.UseMySql("----");
#else
            // TODO: Remove here if not necessary.
            optionsBuilder.UseMySql("----", ServerVersion.FromString("10.5.9")); 
#endif

            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
