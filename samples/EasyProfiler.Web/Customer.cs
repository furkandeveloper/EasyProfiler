using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Web
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreateDate { get; set; }

        //public DateTime UpdateDate { get; set; }
    }
}
