﻿using EasyProfiler.Mongo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Models
{
    /// <summary>
    /// Profiler entity.
    /// </summary>
    public class Profiler : BaseEntity
    {
        public string Query { get; set; }

        public long Duration { get; set; }

        public string RequestUrl { get; set; } = "/";

        public  QueryType QueryType { get; set; }
    }
}
