using cursoInduccion.backend.Data;
using cursoInduccion.backend.Repositories;
using cursoInduccion.backend.Repositories.Impl;
using cursoInduccion.backend.Services;
using cursoInduccion.backend.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MySQLContext");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
         connectionString ?? throw new InvalidOperationException("Connection string 'MySQLContext' not found."),
         ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.
builder.Services.AddControllers();

// Add Injection
builder.Services.AddScoped<IWeatherForecastsService, WeatherForecastsService>();
builder.Services.AddScoped<IWeatherForecastsRepository, WeatherForecastsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
