using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyProfiler.SQLite.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
            optionsBuilder.UseSqlite("Data Source=xxx.db");
            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
