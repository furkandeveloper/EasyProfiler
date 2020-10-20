using EasyProfiler.Entities;
using EasyProfiler.SQLServer.Abstractions;
using EasyProfiler.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Concrete
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
            try
            {
                profiler.Id = Guid.NewGuid();
                profilerDbContext.Profilers.Add(profiler);
                profilerDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
