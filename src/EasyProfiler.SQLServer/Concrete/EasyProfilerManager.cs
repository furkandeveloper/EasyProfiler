using EasyProfiler.Entities;
using EasyProfiler.SQLServer.Abstractions;
using EasyProfiler.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Concrete
{
    public class EasyProfilerManager : IEasyProfilerService
    {
        private readonly ProfilerDbContext profilerDbContext;

        public EasyProfilerManager(ProfilerDbContext profilerDbContext)
        {
            this.profilerDbContext = profilerDbContext;
        }
        public async Task InsertLogAsync(Profiler profiler)
        {
            await profilerDbContext.Profilers.AddAsync(profiler);
            await profilerDbContext.SaveChangesAsync();
        }
    }
}
