using AutoFilterer.Extensions;
using EasyProfiler.AspNetCore.Dtos;
using EasyProfiler.Core.Abstractions;
using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.Core.Helpers.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.AspNetCore.Controllers
{
    /// <summary>
    /// Easy Profiler Endpoints
    /// </summary>
    [ApiController]
    [Route("easy-profiler")]
    public class EasyProfilerController : ControllerBase
    {
        private readonly IEasyProfilerContext easyProfilerContext;

        public EasyProfilerController(IEasyProfilerContext easyProfilerContext)
        {
            this.easyProfilerContext = easyProfilerContext;
        }

        /// <summary>
        /// Filter Profiler
        /// </summary>
        /// <returns>
        /// Status Code : 200 | List of Profiler Response Data Transfer Object
        /// </returns>
        [HttpGet("advanced-filter", Name = "FilterProfiler")]
        [ProducesResponseType(typeof(ProfilerResponseDto[]), 200)]
        public async Task<IActionResult> GetProfilerAsync([FromQuery] AdvancedFilterModel model)
        {
            var profilers = await easyProfilerContext.Get<Profiler>().ApplyFilter(model).Select(s => new ProfilerResponseDto
            {
                Duration = new TimeSpan(s.Duration),
                EndDate = s.EndDate,
                Id = s.Id,
                Query = s.Query,
                QueryType = s.QueryType,
                StartDate = s.StartDate,
                RequestUrl = s.RequestUrl
            }).ToListAsync();
            return Ok(profilers);
        }


        /// <summary>
        /// Get Slowest Endpoint
        /// </summary>
        /// <returns>
        /// Status Code : 200 | List of Slowest Endpoint Response Model
        /// </returns>
        [HttpGet("slowest-endpoint", Name = "GetSlowestEndpoint")]
        [ProducesResponseType(typeof(SlowestEndpointResponseModel[]), 200)]
        public async Task<IActionResult> GetSlowestEndpointAsync()
        {
            var data = await FindEndpointsAsync();
            data = data.OrderByDescending(x => x.AvarageDurationTime).ToList();
            return Ok(data);
        }

        /// <summary>
        /// Get Fastest Endpoint
        /// </summary>
        /// <returns>
        /// Status Code : 200 | List of Slowest Endpoint Response Model
        /// </returns>
        [HttpGet("fastest-endpoint", Name = "GetFastestEndpoint")]
        [ProducesResponseType(typeof(SlowestEndpointResponseModel[]), 200)]
        public async Task<IActionResult> GetFastestEndpointAsync()
        {
            var data = await FindEndpointsAsync();
            data = data.OrderBy(o => o.AvarageDurationTime).ToList();
            return Ok(data);
        }

        /// <summary>
        /// Most Requested Endpoint
        /// </summary>
        /// <returns>
        /// Status Code : 200 | Name-Count Value
        /// </returns>
        [HttpGet("most-requested-endpoint",Name ="MostRequestedEndpoint")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> MostRequestedEndpointAsync()
        {
            var data = await easyProfilerContext.Get<Profiler>().Where(x => !string.IsNullOrEmpty(x.RequestUrl) && x.RequestUrl != "Not Http")
                .GroupBy(g => g.RequestUrl).Select(a => new
                {
                    Name = a.Key,
                    Count = a.Count()
                }).OrderBy(a=>a.Count).ToListAsync();
            return Ok(data);
        }

        [NonAction]
        private async Task<List<SlowestEndpointResponseModel>> FindEndpointsAsync()
        {
            return await easyProfilerContext.Get<Profiler>().Where(x => !string.IsNullOrEmpty(x.RequestUrl) && x.RequestUrl != "Not Http")
                .GroupBy(g => g.RequestUrl).Select(s => new SlowestEndpointResponseModel
                {
                    RequestUrl = s.Key,
                    Count = s.Count(),
                    AvarageDurationTime = new TimeSpan(s.Sum(a => a.Duration) / s.Count())
                }).ToListAsync();
        }
    }
}
