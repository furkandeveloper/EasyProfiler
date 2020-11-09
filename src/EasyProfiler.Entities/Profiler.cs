using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Entities
{
    /// <summary>
    /// Profiler entity.
    /// </summary>
    public class Profiler : BaseEntity
    {
        public string Query { get; set; }

        public TimeSpan Duration { get; set; }

        public string RequestUrl { get; set; } = "/";
    }
}
