using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Helpers.Generators
{
    /// <summary>
    /// Guid value generator for primary key.
    /// </summary>
    public class GuidGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue(EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }
}
