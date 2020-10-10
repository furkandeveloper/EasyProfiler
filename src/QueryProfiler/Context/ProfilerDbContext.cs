using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Context
{
    public class ProfilerDbContext : DbContext
    {
        public ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProfilerDbContext()
        {
        }
    }
}
