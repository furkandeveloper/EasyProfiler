using System;
using System.Collections.Generic;
using System.Text;
#if NETCOREAPP3_1 || NET5_0
using System.Text.Json.Serialization;
#endif

namespace EasyProfiler.CronJob.Common
{
    /// <summary>
    /// Resulation Type
    /// </summary>
#if NETCOREAPP3_1 || NET5_0
    [JsonConverter(typeof(JsonStringEnumConverter))]
#endif
    public enum Resulation
    {
        /// <summary>
        /// Low Resulation
        /// </summary>
        [ResulationCron("*/5 * * * *")]
        LOW = 1,
        /// <summary>
        /// Mid. Resulation
        /// </summary>
        [ResulationCron("*/2 * * * *")]
        MEDIUM,
        /// <summary>
        /// High Resulation
        /// </summary>
        [ResulationCron("* * * * *")]
        HIGH
    }
}
