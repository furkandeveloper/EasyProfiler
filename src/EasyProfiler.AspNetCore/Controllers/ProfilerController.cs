using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProfilerAsync()
        {
            return Ok("Hello Easy Profiler");
        }
    }
}
