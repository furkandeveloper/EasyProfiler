using EasyProfiler.CronJob.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CronConfiguration<T> : ICronConfiguration<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
