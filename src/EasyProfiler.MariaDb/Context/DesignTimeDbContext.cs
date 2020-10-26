using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyProfiler.MariaDb.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Port=3360;Database=KargoEntegrasyon;Uid=entegrasyon;Pwd=entegrasyon;");
            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
