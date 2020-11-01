using EasyProfiler.Core.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.PostgreSQL.Interceptors
{
    /// <summary>
    /// Profiler Interceptors.
    /// </summary>
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerBaseService<ProfilerDbContext> baseService;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService)
        {
            this.baseService = baseService;
        }
        /// <summary>
        /// Data reader Disposing.
        /// </summary>
        /// <param name="command">
        /// DbCommand.
        /// </param>
        /// <param name="eventData">
        /// Event data.
        /// </param>
        /// <param name="result">
        /// Interception result.
        /// </param>
        /// <returns></returns>
        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => baseService.InsertAsync(new Entities.Profiler
            {
                Duration = eventData.Duration,
                Query = command.CommandText
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
