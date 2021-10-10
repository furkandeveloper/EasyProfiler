using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.AspNetCore
{
    public static class Startup
    {
        public static IMvcBuilder AddEasyProfilerControllers(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());
            return builder;
        }
    }
}
