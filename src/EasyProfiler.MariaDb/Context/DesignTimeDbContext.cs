using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyProfiler.MariaDb.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
            optionsBuilder.UseMySql("----");
            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
