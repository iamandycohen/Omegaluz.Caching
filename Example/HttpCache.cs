﻿using Omegaluz.Caching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Example
{
    public class HttpCache : CacheProvider<Cache>
    {
        protected override Cache InitCache()
        {
            return HttpRuntime.Cache;
        }

        public override bool Get<T>(string key, out T value)
        {
            try
            {
                if (_cache[key] == null)
                {
                    value = default(T);
                    return false;
                }

                value = (T)_cache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }

        public override void Set<T>(string key, T value)
        {
            Set<T>(key, value, CacheDuration);
        }

        public override void Set<T>(string key, T value, int duration)
        {
            _cache.Insert(
                key,
                value,
                null,
                DateTime.Now.AddMinutes(duration),
                TimeSpan.Zero);
        }

        public override void Clear(string key)
        {
            _cache.Remove(key);
        }

        public override IEnumerable<KeyValuePair<string, object>> GetAll()
        {

            foreach (DictionaryEntry item in _cache)
            {
                yield return new KeyValuePair<string, object>(item.Key as string, item.Value);
            }

        }
    }
}