using AutoFilterer.Attributes;
using AutoFilterer.Types;
using EasyProfiler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Helpers.AdvancedQuery
{
    /// <summary>
    /// Advanced filter model for profiler entity.
    /// </summary>
#if NET5_0 || NETCOREAPP3_1
    [PossibleSortings("Query", "Duration")]
#endif
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
        /// Request Url
        /// </summary>
        [ToLowerContainsComparison]
        public string RequestUrl { get; set; }

        /// <summary>
        /// Duration.
        /// </summary>
        public Range<long> Duration { get; set; }

        /// <summary>
        /// QueryType. For Example : Select, Update, Insert, Delete.
        /// </summary>
        public QueryType? QueryType { get; set; }
    }
}
