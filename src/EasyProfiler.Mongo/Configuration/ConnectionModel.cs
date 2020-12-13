using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Configuration
{
    /// <summary>
    /// This class includes connection property for Mongo database
    /// </summary>
    public class ConnectionModel
    {
        public string ConnectionString;
        /// <summary>
        /// Database name
        /// </summary>
        public string Database;
    }
}
