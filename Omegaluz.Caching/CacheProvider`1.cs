using System.Collections.Generic;

namespace Omegaluz.Caching
{
    public abstract class CacheProvider<TCache> : ICacheProvider
    {

        public int CacheDuration
        {
            get;
            set;
        }

        private readonly int defaultCacheDurationInMinutes = 30;

        protected TCache _cache;

        public CacheProvider()
        {
            CacheDuration = defaultCacheDurationInMinutes;
            _cache = InitCache();
        }
        public CacheProvider(int durationInMinutes)
        {
            CacheDuration = durationInMinutes;
            _cache = InitCache();
        }

        protected abstract TCache InitCache();

        public abstract bool Get<T>(string key, out T value);

        public abstract void Set<T>(string key, T value);

        public abstract void Set<T>(string key, T value, int duration);

        public abstract void Clear(string key);

        public abstract IEnumerable<KeyValuePair<string, object>> GetAll();

    }
}
