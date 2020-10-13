using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Entities
{
    /// <summary>
    /// Base Entity.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Primary key for table.
        /// </summary>
        public Guid Id { get; set; }
    }
}
