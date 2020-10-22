using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAsync()
        {
            try
            {
                sampleDbContext.Customers.Add(new Customer
                {
                    Name = "Furkan",
                    Surname = "Güngör",
                    CreateDate = DateTime.UtcNow
                });
                sampleDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            var data = sampleDbContext.Customers.ToList();
            return Ok("eee");
        }
    }
}
