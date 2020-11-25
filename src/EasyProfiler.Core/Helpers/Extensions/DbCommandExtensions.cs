using EasyProfiler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EasyProfiler.Core.Helpers.Extensions
{
    /// <summary>
    /// This class includes extensions method for DbCommand are object.
    /// </summary>
    public static class DbCommandExtensions
    {
        /// <summary>
        /// Find query type.
        /// </summary>
        /// <param name="dbCommand">
        /// Represents an SQL statement or stored procedure to execute against a data source.
        /// Provides a base class for database-specific classes that represent commands.
        /// Overload:System.Data.Common.DbCommand.ExecuteNonQueryAsync
        /// </param>
        /// <returns>
        /// Enum of QueryType.
        /// </returns>
        public static QueryType FindQueryType(this DbCommand dbCommand)
        {
            QueryType queryType = QueryType.NONE;
            switch (dbCommand.CommandText.Split(' ')[0].ToLowerInvariant())
            {
                case "select":
                    queryType = QueryType.SELECT;
                    break;
                case "update":
                    queryType = QueryType.UPDATE;
                    break;
                case "delete":
                    queryType = QueryType.DELETE;
                    break;
                case "insert":
                    queryType = QueryType.INSERT;
                    break;
                default:
                    break;
            }
            return queryType;
        }
    }
}
