using EasyProfiler.Core.Entities;
using EasyProfiler.Mongo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BaseEntity = EasyProfiler.Mongo.Entities.BaseEntity;

namespace EasyProfiler.Mongo.Models
{
    /// <summary>
    /// Profiler entity.
    /// </summary>
    public class Profiler : BaseEntity
    {
        /// <summary>
        /// Executed query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Duration of executed query
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Request url of executed query
        /// </summary>
        public string RequestUrl { get; set; } = "/";

        /// <summary>
        /// Query type of executed query
        /// </summary>
        public  QueryType QueryType { get; set; }
    }
}
