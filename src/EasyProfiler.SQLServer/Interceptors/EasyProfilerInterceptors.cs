using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
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
        private readonly IEasyProfilerBaseService<ProfilerDbContext> baseService;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService)
        {
            this.baseService = baseService;
        }

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => baseService.InsertAsync(new Profiler()
            {
                Query = command.CommandText,
                Duration = eventData.Duration.Ticks
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
