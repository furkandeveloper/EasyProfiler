using EasyProfiler.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Abstractions
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
    }
}
