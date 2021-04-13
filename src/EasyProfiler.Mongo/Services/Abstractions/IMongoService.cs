using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using EasyProfiler.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.Mongo.Services.Abstractions
{
    public interface IMongoService
    {
        Task InsertAsync(Profiler profiler);

        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel);

        Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync();
    }
}
