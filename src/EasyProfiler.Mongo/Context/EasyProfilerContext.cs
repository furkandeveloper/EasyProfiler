using EasyProfiler.Mongo.Configuration;
using EasyProfiler.Mongo.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace EasyProfiler.Mongo.Context
{
    /// <summary>
    /// Db context
    /// </summary>
    public class EasyProfilerContext : DbContext, IEasyProfilerContext
    {
        protected readonly IMongoDatabase _database;

        public EasyProfilerContext(ConnectionModel connectionModel)
        {
            var client = new MongoClient(connectionModel.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(connectionModel.Database);
        }

        public IMongoCollection<Profiler> Profilers
            => Database.GetCollection<Profiler>(nameof(Profilers));

        /// <summary>
        /// Database object
        /// </summary>
        public new IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }

        /// <summary>
        /// It's for Entity Framework based queries
        /// </summary>
        /// <typeparam name="T">Type of collection (Table)</typeparam>
        public IMongoCollection<T> Set<T>(string collection = null)
        {
            return Database.GetCollection<T>(collection ?? typeof(T).Name);
        }
    }
}
