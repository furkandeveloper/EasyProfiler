using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.CronJob.Common
{
    public class DbResulationConfiguration
    {
        public Resulation Resulation { get; set; }

        public bool UseCronExpression { get; set; }

        public string CronExpression { get; set; }

        public TimeZoneInfo TimeZoneInfo { get; set; } = TimeZoneInfo.Local;
    }
}
