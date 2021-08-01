using EasyProfiler.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Extensions
{
    /// <summary>
    /// This class includes extensions method for commandName are object.
    /// </summary>
    public static class CommandExtensions
    {
        public static QueryType FindQueryType(this string commandName)
        {
            switch (commandName)
            {
                case "select":
                    return QueryType.SELECT;
                case "update":
                    return QueryType.UPDATE;
                case "delete":
                    return QueryType.DELETE;
                case "insert":
                    return QueryType.INSERT;
                case "find":
                    return QueryType.SELECT;
                case "count":
                    return QueryType.SELECT;
                case "aggregate":
                    return QueryType.SELECT;
                default:
                    return QueryType.OTHER;
            }
        }
    }
}
