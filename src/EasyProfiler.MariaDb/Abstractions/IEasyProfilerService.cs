using System.Collections.Generic;
using System.Threading.Tasks;
using EasyProfiler.Entities;
using EasyProfiler.MariaDb.Models;

namespace EasyProfiler.MariaDb.Abstractions
{
    /// <summary>
    /// This interface includes query log.
    /// </summary>
    public interface IEasyProfilerService
    {
        /// <summary>
        /// Insert Query Log.
        /// </summary>
        /// <param name="profiler">
        /// Profiler Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        Task InsertLogAsync(Profiler profiler);

        /// <summary>
        /// Advanced filter.
        /// </summary>
        /// <param name="filterModel">
        /// Filter object.
        /// </param>
        /// <returns>
        /// List of profiler.
        /// </returns>
        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel filterModel);
    }
}
