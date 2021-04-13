using System;
using System.Collections.Generic;
using System.Text;
#if NETCOREAPP3_1 || NET5_0
using System.Text.Json.Serialization;
#endif

namespace EasyProfiler.CronJob.Common
{
#if NETCOREAPP3_1 || NET5_0
    [JsonConverter(typeof(JsonStringEnumConverter))]
#endif
    public enum Resulation
    {
        /// <summary>
        /// 
        /// </summary>
        //[ResulationCron("*/2 * * * *")]
        [ResulationCron("* * * * *")]
        LOW = 1,
        /// <summary>
        /// 
        /// </summary>
        [ResulationCron("*/2 * * * *")]
        MEDIUM,
        /// <summary>
        /// 
        /// </summary>
        [ResulationCron("*/2 * * * *")]
        HIGH
    }
}
