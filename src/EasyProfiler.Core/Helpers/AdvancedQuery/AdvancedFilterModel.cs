using AutoFilterer.Attributes;
using AutoFilterer.Types;
using EasyProfiler.Core.Entities;

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
