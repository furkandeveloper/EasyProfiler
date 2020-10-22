using EasyProfiler.SQLServer.Abstractions;
using EasyProfiler.SQLServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly SampleDbContext sampleDbContext;

        public DefaultController(SampleDbContext sampleDbContext)
        {
            this.sampleDbContext = sampleDbContext;
        }

        [HttpPost("InsertCustomers")]
        public async Task<IActionResult> InsertCustomerAsync()
        {
            for (int i = 0; i < 10000; i++)
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

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok(await sampleDbContext.Customers.ToListAsync());
        }

        [HttpGet("AdvancedFilterForEasyProfiler")]
        public async Task<IActionResult> AdvancedFilterForEasyProfilerAsync([FromQuery] AdvancedFilterModel model,[FromServices] IEasyProfilerService easyProfilerService)
        {
            return Ok(await easyProfilerService.AdvancedFilterAsync(model));
        }
    }
}
