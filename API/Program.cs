using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Infrastructure Services
builder.Services.AddDbContext<StoreContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AdvWorksConnectionString")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
    
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
