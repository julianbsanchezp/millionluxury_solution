using Million.Luxury.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Million.Luxury.Application.Ports;
using Million.Luxury.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración de EF Core con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registramos el repositorio
builder.Services.AddScoped<IPropertyRepository, SqlPropertyRepository>();

// Add services to the container.
builder.Services.AddControllers(); // 👈 Importante para habilitar los controladores
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

// habilita los controladores como PropertiesController
app.MapControllers();

app.Run();

// Necesario para pruebas e integración con EF
public partial class Program { }
