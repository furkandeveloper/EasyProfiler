using EasyProfiler.Mongo.Configuration;
using EasyProfiler.Mongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EasyProfiler.Core.Abstractions;

namespace EasyProfiler.Mongo.Context
{
    /// <summary>
    /// Db context
    /// </summary>
    public class EasyProfilerMongoDbContext : IEasyProfilerContext
    {
        protected readonly IMongoDatabase _database;

        public EasyProfilerMongoDbContext(ConnectionModel connectionModel)
        {
            var client = new MongoClient(connectionModel.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(connectionModel.Database);
        }

        /// <summary>
        /// Database object
        /// </summary>
        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }
        
        public IQueryable<T> Get<T>() where T : class
        {
           return Database.GetCollection<T>(typeof(T).Name).AsQueryable();
        }

        public Task InsertAsync<T>(T entity) where T : class
        {
            return Database.GetCollection<T>(typeof(T).Name).InsertOneAsync(entity);
        }
    }
}
