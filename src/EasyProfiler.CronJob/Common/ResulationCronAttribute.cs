using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Common
{
    /// <summary>
    /// Resulation Cron Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ResulationCronAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cron">
        /// Cron Expression in string format
        /// </param>
        public ResulationCronAttribute(string cron)
        {
            this.Cron = cron;
        }

        /// <summary>
        /// Cron Expression
        /// </summary>
        public string Cron { get; }
    }
}
