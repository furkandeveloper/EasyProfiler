using AutoFilterer.Extensions;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task InsertAsync(Profiler profiler)
        {
            var entity = dbContext.Entry(profiler);
            entity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }
    }
}
