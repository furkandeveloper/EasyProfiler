using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Entities
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
