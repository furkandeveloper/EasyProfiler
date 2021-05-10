using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Common
{
    /// <summary>
    /// Database Resulation Configuration Object
    /// </summary>
    public class DbResulationConfiguration
    {
        /// <summary>
        /// Resulation Type
        /// </summary>
        public Resulation Resulation { get; set; }

        /// <summary>
        /// Is use cron expression?
        /// </summary>
        public bool UseCronExpression { get; set; }

        /// <summary>
        /// Cron Expression is required if UseCronExpression true 
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// Represents any time zone in the world.
        /// </summary>
        /// <remarks>
        /// Default Value : TimeZoneInfo.Local
        /// </remarks>
        public TimeZoneInfo TimeZoneInfo { get; set; } = TimeZoneInfo.Local;
    }
}
