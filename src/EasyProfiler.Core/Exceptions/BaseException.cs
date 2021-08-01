using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
