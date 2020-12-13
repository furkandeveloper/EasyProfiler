using AutoFilterer.Extensions;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using EasyProfiler.Mongo.Context;
using EasyProfiler.Mongo.Models;
using EasyProfiler.Mongo.Services.Abstractions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.Mongo.Services.Concrete
{
    public class MongoService : IMongoService
    {
        private readonly IEasyProfilerContext easyProfilerContext;

        public MongoService(IEasyProfilerContext easyProfilerContext)
        {
            this.easyProfilerContext = easyProfilerContext;
        }
        public Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel)
        {
            return Task.FromResult(easyProfilerContext.Profilers.AsQueryable().ApplyFilter(advancedFilterModel).ToList());
        }

        public Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync()
        {
            var data = easyProfilerContext.Profilers.AsQueryable().Where(x => !string.IsNullOrEmpty(x.RequestUrl) && x.RequestUrl != "/").ToList();
            var grouppingData = data.GroupBy(g => g.RequestUrl).Select(s => new SlowestEndpointResponseModel
            {
                RequestUrl = s.Key,
                Count = s.Count(),
                AvarageDurationTime = new TimeSpan(s.Sum(a => a.Duration) / s.Count())
            }).ToList();
            return Task.FromResult(grouppingData.OrderByDescending(x => x.AvarageDurationTime).ToList());
        }

        public async Task InsertAsync(Profiler profiler)
        {
            await easyProfilerContext.Profilers.InsertOneAsync(profiler);
        }
    }
}
