using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Infrastructure Services
builder.Services.AddDbContext<StoreContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AdvWorksConnectionString"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Add ExceptionMiddleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.UseCors( n => n.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("https://localhost:4200", "http://localhost:4200"));
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
