using EasyProfiler.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Statics
{
    public static class MongoValues
    {
        public static List<Profiler> Profilers { get; set; } = new List<Profiler>();
    }
}
