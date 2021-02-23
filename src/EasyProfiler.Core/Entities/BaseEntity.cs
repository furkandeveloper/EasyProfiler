using System;

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
