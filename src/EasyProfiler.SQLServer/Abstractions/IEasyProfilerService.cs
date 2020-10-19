using EasyProfiler.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.SQLServer.Abstractions
{
    public interface IEasyProfilerService
    {
        Task InsertLogAsync(Profiler profiler);
    }
}
