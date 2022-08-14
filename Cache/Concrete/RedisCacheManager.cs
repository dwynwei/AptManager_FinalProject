using Cache.Abstract;
using Models.CacheEntities;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Concrete
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisEndpoint _endpoint;

        public RedisCacheManager(RedisEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public void Add(string key, object value, int duration)
        {
            using (var client = new RedisClient(_endpoint))
            {
                client.Set(key, value, TimeSpan.FromMinutes(duration));
            }
        }

        public T Get<T>(string key)
        {
            using(var client = new RedisClient(_endpoint))
            {
                return client.Get<T>(key);
            }
        }

        public object Get(string key)
        {
            using (var client = new RedisClient(_endpoint))
            {
                return client.Get(key);
            }
        }

        public bool IsAdd(string key)
        {
            using (var redisClient = new RedisClient(_endpoint))
            {
                return redisClient.ContainsKey(key);
            }
        }

        public void Remove(string key)
        {
            using (var redisClient = new RedisClient(_endpoint))
            {
                redisClient.Remove(key);
            }
        }

        public void RemovebyPattern(string pattern)
        {
            using (var redisClient = new RedisClient(_endpoint))
            {
                redisClient.RemoveByPattern(pattern);
            }
        }

        void ICacheManager.Add(string key, object value)
        {
            using (var client = new RedisClient(_endpoint))
            {
                client.Set(key, value);
            }
        }
    }
}
