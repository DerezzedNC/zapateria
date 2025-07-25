using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Conexión a SQL Server en Somee
builder.Services.AddDbContext<ZapateriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZapateriaDB"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger habilitado SIEMPRE (no solo en desarrollo)
app.UseSwagger();
app.UseSwaggerUI();

// IMPORTANTE: No uses redirección HTTPS en Render
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
