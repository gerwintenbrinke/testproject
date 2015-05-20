using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrenRegistratie.Framework.DataCache
{
    /// <summary>
    /// Caching mechanism
    /// </summary>
    public class Cache
    {        
        private static Cache _dataCache = null;
        Dictionary<string, object> _cache = null;

        public Cache()
        {            
        }

        public static Cache Current()
        {
            if (_dataCache == null)
                _dataCache = new Cache();

            return _dataCache;
        }

        private CacheItem<T> GetCacheItem<T>(string cacheKey, Func<T> function)
        {
            CacheItem<T> cacheItem = new CacheItem<T>();
            cacheItem.Loaded = false;
            cacheItem.TimeCreated = new DateTime(1900, 1, 1);
            cacheItem.LoadFunction = function;

            if (_cache == null)
                _cache = new Dictionary<string, object>();

            if (!_cache.ContainsKey(cacheKey))
                _cache.Add(cacheKey, cacheItem);
            else
                cacheItem = (CacheItem<T>)_cache[cacheKey];
            
            return cacheItem;
            
        }

        /// <summary>
        /// Get data from cache or use the function to retreive the data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="refreshtime"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public T GetData<T>(string key, TimeSpan refreshtime, Func<T> function)
        {
            string cacheKey = key;

            CacheItem<T> cacheItem = GetCacheItem<T>(cacheKey, function);
            lock (cacheItem)
            {
                if (cacheItem.TimeCreated.AddMinutes(refreshtime.TotalMinutes) < DateTime.Now || cacheItem.Data == null)
                {
                    FillCache(function, cacheItem);
                }
            }
            return cacheItem.Data;
        }

        /// <summary>
        /// Remove the item with the key from the cache
        /// </summary>
        /// <param name="key"></param>
        public void RemoveFromCache(string key)
        {            
            if (_cache == null || _cache.Count == 0)
                return;

            _cache.Remove(key);
        }

        private void FillCache<T>(Func<T> function, CacheItem<T> cacheItem)
        {
            cacheItem.TimeCreated = DateTime.Now;
            cacheItem.Data = function();
        }
    }
}