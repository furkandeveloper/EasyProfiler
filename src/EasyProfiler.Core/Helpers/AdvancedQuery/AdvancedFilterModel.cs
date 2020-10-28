using AutoFilterer.Attributes;
using AutoFilterer.Types;
using EasyProfiler.Core.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Helpers.AdvancedQuery
{
    /// <summary>
    /// Advanced filter model for profiler entity.
    /// </summary>
    [PossibleSortings("Query", "Duration")]
    public class AdvancedFilterModel : PaginationFilterBase
    {
        public AdvancedFilterModel()
        {
            this.Sort = "Duration";
            this.SortBy = AutoFilterer.Enums.Sorting.Descending;
        }
        /// <summary>
        /// SQL Query.
        /// </summary>
        [ToLowerContainsComparison]
        public string Query { get; set; }

        /// <summary>
        /// Query duration.
        /// </summary>
        public Range<TimeSpan> Duration { get; set; }
    }
}
