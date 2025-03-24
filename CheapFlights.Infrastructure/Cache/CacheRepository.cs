using System.Runtime.Caching;

namespace CheapFlights.Infrastructure.Cache
{
    public static class CacheRepository
    {
        public static void Add<T>(this ObjectCache objectCache, string key, T entry, CacheItemPolicy policy)
        {
            var cachedValue = new Lazy<T>(() => entry);
            objectCache.Set(key, cachedValue, policy);
        }

        public static void TryGet<T>(this ObjectCache objectCache, string key, out T entry)
        {
            var cachedLazy = objectCache.Get(key) as Lazy<T>;

            entry = cachedLazy != null ? cachedLazy.Value : default(T);
        }

    }
}
