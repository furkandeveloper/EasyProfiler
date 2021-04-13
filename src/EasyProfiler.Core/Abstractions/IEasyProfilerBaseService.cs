using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyProfiler.Core.Abstractions
{
    public interface IEasyProfilerBaseService<TDbContext> where TDbContext : IEasyProfilerContext
    {
        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel);

        Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync();
    }
}
