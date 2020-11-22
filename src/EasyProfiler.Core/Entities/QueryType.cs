using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EasyProfiler.Core.Entities
{
    /// <summary>
    /// SQL Query type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
