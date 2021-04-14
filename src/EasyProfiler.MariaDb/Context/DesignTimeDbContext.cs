using EasyProfiler.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyProfiler.MariaDb.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerMariaDbContext>
    {
        public ProfilerMariaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerMariaDbContext>();
#if NETCOREAPP3_1
            optionsBuilder.UseMySql("----");
#elif NET5_0_OR_GREATER
            // TODO: Remove here if not necessary.
            optionsBuilder.UseMySql("----", ServerVersion.FromString("10.5.9")); 
#endif

            return new ProfilerMariaDbContext(optionsBuilder.Options);
        }
    }
}
