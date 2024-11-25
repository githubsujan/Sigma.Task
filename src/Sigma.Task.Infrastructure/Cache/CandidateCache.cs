using Microsoft.Extensions.Caching.Memory;

using Sigma.Task.Core.Entities;

namespace Sigma.Task.Infrastructure.Cache
{
    public class CandidateCache
    {
        private readonly IMemoryCache _cache;

        public CandidateCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void CreateEntry(string key, IEnumerable<Candidate> value)
        {
            MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions()
               .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
               .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            _cache.Set(key, value, _cacheEntryOptions);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public bool TryGetValue(string key, out IEnumerable<Candidate> value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }
}
