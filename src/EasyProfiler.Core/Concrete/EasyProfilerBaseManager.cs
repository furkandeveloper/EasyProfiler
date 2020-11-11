using AutoFilterer.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.Core.Concrete
{
    public class EasyProfilerBaseManager<TDbContext> : IEasyProfilerBaseService<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public EasyProfilerBaseManager(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel)
        {
            return await dbContext.Set<Profiler>().ApplyFilter(advancedFilterModel).ToListAsync();
        }

        public async Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync()
        {
            var data = await dbContext.Set<Profiler>().Where(x => !string.IsNullOrEmpty(x.RequestUrl) && x.RequestUrl != "/")
                .GroupBy(g => g.RequestUrl).Select(s => new SlowestEndpointResponseModel
                {
                    RequestUrl = s.Key,
                    Count = s.Count(),
                    AvarageDurationTime = new TimeSpan(s.Sum(a => a.Duration) / s.Count())
                }).ToListAsync();
            return data.OrderByDescending(x=>x.AvarageDurationTime).ToList();
        }

        public async Task InsertAsync(Profiler profiler)
        {
            var entity = dbContext.Entry(profiler);
            entity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }
    }
}
