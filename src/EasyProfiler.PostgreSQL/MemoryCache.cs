using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.PostgreSQL
{
    public class MemoryCache : IProfilerCache
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public T Get<T>(string key)
        {
            var data = memoryCache.Get<T>(key);
            if (data == null) return default(T);
            return data;
        }

        public void Remove<T>(string key)
        {
            memoryCache.Remove(key);
        }

        public void Set<T>(string key, T value, TimeSpan expireTime)
        {
            memoryCache.Set(key, value, expireTime);
        }
    }

    public interface IProfilerCache
    {
        void Set<T>(string key, T value, TimeSpan expireTime);

        T Get<T>(string key);

        void Remove<T>(string key);
    }
}
