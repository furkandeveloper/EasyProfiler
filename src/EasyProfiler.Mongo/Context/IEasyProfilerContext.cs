using EasyProfiler.Mongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Mongo.Context
{
    /// <summary>
    /// This interface includes database objects.
    /// </summary>
    public interface IEasyProfilerContext
    {
        /// <summary>
        /// Profiler entity.
        /// </summary>
        IMongoCollection<Profiler> Profilers { get; }

        /// <summary>
        /// Set entity (collection)
        /// </summary>
        /// <typeparam name="T">
        /// Entity type
        /// </typeparam>
        /// <param name="collection">
        /// Collection name
        /// </param>
        /// <returns></returns>
        IMongoCollection<T> Set<T>(string collection = null);

        /// <summary>
        /// Database root object
        /// </summary>
        IMongoDatabase Database { get; }
    }
}
