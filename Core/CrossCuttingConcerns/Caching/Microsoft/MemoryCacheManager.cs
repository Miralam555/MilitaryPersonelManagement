using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        private readonly IMemoryCache _memoryCache;
        private readonly HashSet<string> _cacheKeys; 

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cacheKeys = new HashSet<string>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
            _cacheKeys.Add(key); 
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            _cacheKeys.Remove(key); 
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = _cacheKeys.Where(k => regex.IsMatch(k)).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
                _cacheKeys.Remove(key);
            }
        }
    }
}
