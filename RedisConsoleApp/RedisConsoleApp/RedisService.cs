using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    internal class RedisService : ICacheService
    {
        private IDatabase _db;
        public RedisService(IConnectionMultiplexer connection)
        {
            _db = connection.GetDatabase();
        }
        public void Delete(string key)
        {
            _db.KeyDelete(key);    
        }

        public T Get<T>(string key)
        {
            var dataStr = _db.StringGet(key);

            return JsonSerializer.Deserialize<T>(dataStr);
        }

        public void Set<T>(string key, T value)
        {
            _db.StringSet(key, JsonSerializer.Serialize(value));
        }
    }
}
