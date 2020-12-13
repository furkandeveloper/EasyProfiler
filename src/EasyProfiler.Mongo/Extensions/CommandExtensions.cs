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
            QueryType queryType = QueryType.NONE;
            switch (commandName)
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
                case "find":
                    queryType = QueryType.SELECT;
                    break;
                case "count":
                    queryType = QueryType.SELECT;
                    break;
                case "aggregate":
                    queryType = QueryType.SELECT;
                    break;
                default:
                    queryType = QueryType.OTHER;
                    break;
            }
            return queryType;
        }
    }
}
