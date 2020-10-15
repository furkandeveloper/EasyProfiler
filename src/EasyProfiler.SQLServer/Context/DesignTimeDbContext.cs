using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.SQLServer.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerDbContext>
    {
        public ProfilerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerDbContext>();
            optionsBuilder.UseSqlServer("xxxx");
            return new ProfilerDbContext(optionsBuilder.Options);
        }
    }
}
