using System.Data.Common;
using System.Threading.Tasks;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.SQLite.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyProfiler.SQLite.Interceptors
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
