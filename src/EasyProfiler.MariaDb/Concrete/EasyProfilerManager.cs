using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFilterer.Extensions;
using EasyProfiler.Entities;
using EasyProfiler.MariaDb.Abstractions;
using EasyProfiler.MariaDb.Context;
using EasyProfiler.MariaDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyProfiler.MariaDb.Concrete
{
    /// <summary>
    /// This class includes query log.
    /// </summary>
    public class EasyProfilerManager : IEasyProfilerService
    {
        private readonly ProfilerDbContext profilerDbContext;

        public EasyProfilerManager(ProfilerDbContext profilerDbContext)
        {
            this.profilerDbContext = profilerDbContext;
        }

        /// <summary>
        /// Advanced filter.
        /// </summary>
        /// <param name="filterModel">
        /// Filter object.
        /// </param>
        /// <returns>
        /// List of profiler.
        /// </returns>
        public async Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel filterModel)
        {
            return await profilerDbContext.Profilers.ApplyFilter(filterModel).ToListAsync();
        }

        /// <summary>
        /// Insert Query Log.
        /// </summary>
        /// <param name="profiler">
        /// Profiler Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public async Task InsertLogAsync(Profiler profiler)
        {
            profiler.Id = Guid.NewGuid();
            await profilerDbContext.Profilers.AddAsync(profiler);
            await profilerDbContext.SaveChangesAsync();
        }
    }
}
