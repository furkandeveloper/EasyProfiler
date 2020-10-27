using System.Data.Common;
using System.Threading.Tasks;
using EasyProfiler.MariaDb.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyProfiler.MariaDb.Interceptors
{
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerService easyProfilerService;

        public EasyProfilerInterceptors(IEasyProfilerService easyProfilerService)
        {
            this.easyProfilerService = easyProfilerService;
        }

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => easyProfilerService.InsertLogAsync(new Entities.Profiler()
            {
                Query = command.CommandText,
                Duration = eventData.Duration
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
