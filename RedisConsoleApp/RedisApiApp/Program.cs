using RedisApiApp.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICacheService, RedisService>();

builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
{
    var config = ConfigurationOptions.Parse("localhost:6379", true);
    return ConnectionMultiplexer.Connect(config);
});

builder.Services.AddStackExchangeRedisOutputCache(opt =>
{
    opt.InstanceName = "localhost";
    opt.Configuration = "localhost:6379";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOutputCache();

app.Run();
