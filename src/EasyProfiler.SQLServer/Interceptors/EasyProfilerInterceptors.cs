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

namespace EasyProfiler.SQLServer.Interceptors
{
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerBaseService<ProfilerDbContext> baseService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService,IHttpContextAccessor httpContextAccessor)
        {
            this.baseService = baseService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => baseService.InsertAsync(new Profiler()
            {
                Query = command.CommandText,
                Duration = eventData.Duration.Ticks,
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
                QueryType = command.FindQueryType()
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
