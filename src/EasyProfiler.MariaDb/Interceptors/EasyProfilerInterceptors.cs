using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Statics;
using EasyProfiler.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;

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
                RequestUrl = httpContextAccessor.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint?.DisplayName ?? "Not Http",
                QueryType = command.FindQueryType(),
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow - eventData.Duration
            };
            Values.Profilers.Add(profilerData);
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
