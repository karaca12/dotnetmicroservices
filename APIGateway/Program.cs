using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
