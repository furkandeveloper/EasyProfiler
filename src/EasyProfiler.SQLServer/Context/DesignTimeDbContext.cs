using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using EasyProfiler.EntityFrameworkCore;

namespace EasyProfiler.SQLServer.Context
{
    internal class DesignTimeDbContext : IDesignTimeDbContextFactory<ProfilerSqlServerDbContext>
    {
        public ProfilerSqlServerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProfilerSqlServerDbContext>();
            optionsBuilder.UseSqlServer("xxxx");
            return new ProfilerSqlServerDbContext(optionsBuilder.Options);
        }
    }
}
