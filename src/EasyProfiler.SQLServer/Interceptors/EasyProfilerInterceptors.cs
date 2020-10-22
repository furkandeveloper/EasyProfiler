using EasyProfiler.SQLServer.Abstractions;
using EasyProfiler.SQLServer.Context;
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
