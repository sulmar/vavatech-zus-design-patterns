using DecoratorPattern.Abstractions;
using DecoratorPattern.Infrastructures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<DbProductRepository>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
