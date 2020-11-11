using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using EasyProfiler.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.Core.Abstractions
{
    public interface IEasyProfilerBaseService<TDbContext> where TDbContext : DbContext
    {
        Task InsertAsync(Profiler profiler);

        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel);

        Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync();
    }
}
