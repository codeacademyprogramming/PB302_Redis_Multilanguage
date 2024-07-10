

using RedisConsoleApp;
using StackExchange.Redis;

var redis = ConnectionMultiplexer.Connect("localhost:6379");

ICacheService redisService = new RedisService(redis);


var pr = new Product
{
    Id = 1,
    Name = "Product 1"
};
redisService.Set<Product>("pr-" + pr.Id, pr);


Console.WriteLine(redisService.Get<Product>("pr-1"));