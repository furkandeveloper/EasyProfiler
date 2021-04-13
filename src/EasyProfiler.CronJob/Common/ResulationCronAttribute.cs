using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ResulationCronAttribute : Attribute
    {
        public ResulationCronAttribute(string cron)
        {
            this.Cron = cron;
        }

        public string Cron { get; }
    }
}
