using AutoFilterer.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyProfiler.Core.Helpers.Extensions;

namespace EasyProfiler.Core.Concrete
{
    public class EasyProfilerBaseManager<TDbContext> : IEasyProfilerBaseService<TDbContext> where TDbContext : IEasyProfilerContext
    {
        private readonly TDbContext dbContext;

        public EasyProfilerBaseManager(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel)
        {
            return await dbContext.Get<Profiler>().ApplyFilter(advancedFilterModel).ToListAsync();
        }

        public virtual async Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync()
        {
            var data = await dbContext.Get<Profiler>().Where(x => !string.IsNullOrEmpty(x.RequestUrl) && x.RequestUrl != "Not Http")
                .GroupBy(g => g.RequestUrl).Select(s => new SlowestEndpointResponseModel
                {
                    RequestUrl = s.Key,
                    Count = s.Count(),
                    AvarageDurationTime = new TimeSpan(s.Sum(a => a.Duration) / s.Count())
                }).ToListAsync();
            return data.OrderByDescending(x=>x.AvarageDurationTime).ToList();
        }
    }
}
