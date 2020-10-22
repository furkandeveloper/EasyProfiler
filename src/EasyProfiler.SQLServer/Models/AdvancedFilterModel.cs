using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.SQLServer.Models
{
    /// <summary>
    /// Advanced filter model for profiler entity.
    /// </summary>
    [PossibleSortings("Query","Duration")]
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
        public string Query { get; set; }

        /// <summary>
        /// Query duration.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
