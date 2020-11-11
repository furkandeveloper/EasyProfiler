using System.Data.Common;
using System.Threading.Tasks;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.MariaDb.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyProfiler.MariaDb.Interceptors
{
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerBaseService<ProfilerDbContext> baseService;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService)
        {
            this.baseService = baseService;
        }

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => baseService.InsertAsync(new Entities.Profiler()
            {
                Query = command.CommandText,
                Duration = eventData.Duration.Ticks
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
