using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EasyProfiler.Web.Dotnet6.Controllers
{
    /// <summary>
    /// Default Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly SampleDbContext sampleDbContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="sampleDbContext">
        /// DB Context
        /// </param>
        public DefaultController(SampleDbContext sampleDbContext)
        {
            this.sampleDbContext = sampleDbContext;
        }

        /// <summary>
        /// Insert Customers
        /// </summary>
        /// <returns>
        /// NoContent
        /// </returns>
        [HttpPost("InsertCustomers")]
        [NonAction]
        public async Task<IActionResult> InsertCustomerAsync()
        {
            for (int i = 0; i < 12; i++)
            {
                await sampleDbContext.Customers.AddAsync(new Customer
                {
                    Name = "Customer Name " + i,
                    Surname = "Customer Surname " +i,
                    CreateDate = DateTime.UtcNow
                });
            }
            await sampleDbContext.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Get All Customers.
        /// </summary>
        /// <returns>
        /// List of customers.
        /// </returns>
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok(await sampleDbContext.Customers.ToListAsync());
        }

        /// <summary>
        /// Advanced filter for easy profiler.
        /// </summary>
        /// <param name="model">
        /// Advanced filter model.
        /// </param>
        /// <param name="baseService">
        /// Easy profiler service.
        /// </param>
        /// <returns>
        /// List of profiler.
        /// </returns>
        [HttpGet("AdvancedFilterForEasyProfiler")]
        public async Task<IActionResult> AdvancedFilterForEasyProfilerAsync([FromQuery] AdvancedFilterModel model,[FromServices]IEasyProfilerBaseService<ProfilerPostgreSqlDbContext> baseService)
        {
            return Ok(await baseService.AdvancedFilterAsync(model));
        }

        /// <summary>
        /// Find slowest endpoint.
        /// </summary>
        /// <param name="baseService">
        /// EasyProfilerBaseService
        /// </param>
        /// <returns>
        /// List of SlowestEndpointResponseModel.
        /// </returns>
        [HttpGet("SlowestEndpoint")]
        public async Task<IActionResult> SlowestEndpointAsync([FromServices] IEasyProfilerBaseService<ProfilerPostgreSqlDbContext> baseService)
        {
             return Ok(await baseService.GetSlowestEndpointsAsync());
        }
    }
}
