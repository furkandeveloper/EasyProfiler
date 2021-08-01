using System.Data.Common;
using EasyProfiler.Core.Entities;

namespace EasyProfiler.EntityFrameworkCore.Extensions
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
            switch (dbCommand.CommandText.Split(' ')[0].ToLowerInvariant())
            {
                case "select":
                    return QueryType.SELECT;
                case "update":
                    return QueryType.UPDATE;
                case "delete":
                    return QueryType.DELETE;
                case "insert":
                    return QueryType.INSERT;
                default:
                    return QueryType.OTHER;
            }
        }
    }
}
