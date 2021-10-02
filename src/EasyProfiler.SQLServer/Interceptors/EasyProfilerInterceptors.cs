using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.SQLServer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyProfiler.EntityFrameworkCore.Extensions;
using EasyProfiler.Core.Statics;

namespace EasyProfiler.SQLServer.Interceptors
{
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public EasyProfilerInterceptors(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            var profilerData = new Profiler
            {
                Duration = eventData.Duration.Ticks,
                Query = command.CommandText,
                RequestUrl = httpContextAccessor?.HttpContext?.GetEndpoint()?.DisplayName ?? "Not Http",
                QueryType = command.FindQueryType(),
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow - eventData.Duration
            };
            Values.Profilers.Add(profilerData);
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
