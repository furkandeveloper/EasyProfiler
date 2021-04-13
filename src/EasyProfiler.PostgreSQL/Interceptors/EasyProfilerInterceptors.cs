using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EasyProfiler.EntityFrameworkCore.Extensions;

namespace EasyProfiler.PostgreSQL.Interceptors
{
    /// <summary>
    /// Profiler Interceptors.
    /// </summary>
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EasyProfilerInterceptors(IEasyProfilerContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
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
            Task.Run(() => context.InsertAsync(new Profiler
            {
                Duration = eventData.Duration.Ticks,
                Query = command.CommandText,
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
                QueryType = command.FindQueryType()
            }));
            
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
