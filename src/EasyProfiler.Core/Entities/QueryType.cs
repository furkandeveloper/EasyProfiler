using System;
using System.Collections.Generic;
using System.Text;
#if NETCOREAPP3_1 || NET5_0
using System.Text.Json.Serialization;
#endif

namespace EasyProfiler.Core.Entities
{
    /// <summary>
    /// SQL Query type.
    /// </summary>
#if NETCOREAPP3_1 || NET5_0
    [JsonConverter(typeof(JsonStringEnumConverter))]
#endif
    public enum QueryType
    {
        NONE,
        SELECT,
        INSERT,
        UPDATE,
        DELETE,
        OTHER
    }
}
