using System;
using System.Data.Common;
using System.Threading.Tasks;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.Core.Statics;
using EasyProfiler.EntityFrameworkCore.Extensions;
using EasyProfiler.MariaDb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyProfiler.MariaDb.Interceptors
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
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
                QueryType = command.FindQueryType(),
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow - eventData.Duration
            };
            Values.Profilers.Add(profilerData);
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
