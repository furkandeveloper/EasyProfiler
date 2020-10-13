using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Entities
{
    /// <summary>
    /// Profiler entity.
    /// </summary>
    public class Profiler : BaseEntity
    {
        public string Query { get; set; }

        public int Duration { get; set; }
    }
}
