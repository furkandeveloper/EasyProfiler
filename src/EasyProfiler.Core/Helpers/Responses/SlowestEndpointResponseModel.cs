using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Helpers.Responses
{
    public class SlowestEndpointResponseModel
    {
        public string RequestUrl { get; set; }

        public int Count { get; set; }

        public TimeSpan AvarageDurationTime { get; set; }
    }
}
