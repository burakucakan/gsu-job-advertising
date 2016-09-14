using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web;
using System.Collections;

namespace GSUKariyer.COMMON
{
    #region CacheDuration
    public struct CacheDuration
    {
        public const int None = 0;
        public const int OneYear = 31536000;
        public const int OneMonth = 2592000;
        public const int OneWeek = 604800;
        public const int OneDay = 86400;
        public const int TwelveHours = 43200;
        public const int SixHours = 21600;
        public const int OneHour = 3600;
        public const int TenMinutes = 360;
        public const int FiveMinutes = 180;
    }
    #endregion

    public class CacheManager<K, V>
    {
        private static CacheManager<K, V> _instance = null;
        private static readonly object _instanceLock = new object();

        /// <summary>
        /// Disable default constructor to enable singleton.
        /// </summary>
        private CacheManager() { }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V this[K key]
        {
            get { return (V)HttpRuntime.Cache[CreateKey(key)]; }
        }

        /// <summary>
        /// Returns given ID's object exist in cache or not.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(K key)
        {
            return HttpRuntime.Cache[CreateKey(key)] != null;
        }

        /// <summary>
        /// Returns object from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            return (V)HttpRuntime.Cache.Get(CreateKey(key));
        }

        /// <summary>
        /// Singleton, works on signle instance.
        /// </summary>
        /// <returns></returns>
        public static CacheManager<K, V> GetInstance()
        {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new CacheManager<K, V>();
            return _instance;
        }

        /// <summary>
        /// Inserts given object into cache untill from now to given duration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInSeconds"></param>
        public void Insert(K key, V value, int cacheDurationInSeconds)
        {
            Insert(key, value, cacheDurationInSeconds, CacheItemPriority.Default);
        }

        /// <summary>
        /// Allows insert object into cache by CachePriority param.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInSeconds"></param>
        /// <param name="priority"></param>
        public void Insert(K key, V value, int cacheDurationInSeconds, CacheItemPriority priority)
        {
            string keyString = CreateKey(key);
            HttpRuntime.Cache.Insert(keyString, value, null, DateTime.Now.AddSeconds(cacheDurationInSeconds), Cache.NoSlidingExpiration, priority, null);
        }

        /// <summary>
        /// Clears given ID's object from cache.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            HttpRuntime.Cache.Remove(CreateKey(key));
        }

        /// <summary>
        /// Removes all cached items from cache and returns removed items name list.
        /// </summary>
        public List<K> RemoveAll()
        {
            List<K> keys = new List<K>();

            // retrieve application Cache enumerator
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();

            // copy all keys that currently exist in Cache
            while (enumerator.MoveNext())
            {
                keys.Add((K)enumerator.Key);
            }

            // delete every key from cache
            for (int i = 0; i < keys.Count; i++)
            {
                HttpRuntime.Cache.Remove(keys[i].ToString());
            }

            return keys;
        }

        /// <summary>
        /// Creates a unique key using given data type and HashCode.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string CreateKey(K key)
        {
            return key + typeof(K).ToString() + key.GetHashCode();
        }
    }
}
