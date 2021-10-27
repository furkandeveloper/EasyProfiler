using EasyProfiler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.AspNetCore.Dtos
{
    /// <summary>
    /// Profiler Response Data Transfer Object
    /// </summary>
    internal class ProfilerResponseDto : BaseResponseDto
    {
        /// <summary>
        /// Query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Duration of Query
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Request Info
        /// </summary>
        public string RequestUrl { get; set; } = "/";

        /// <summary>
        /// Query Type
        /// </summary>
        public QueryType QueryType { get; set; }
    }
}
