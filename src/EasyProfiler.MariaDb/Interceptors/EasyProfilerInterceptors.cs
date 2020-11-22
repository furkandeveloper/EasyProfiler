using System.Data.Common;
using System.Threading.Tasks;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.MariaDb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyProfiler.MariaDb.Interceptors
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
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
