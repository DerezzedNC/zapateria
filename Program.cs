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

// Swagger habilitado siempre
app.UseSwagger();
app.UseSwaggerUI();

// === NUEVO: Habilitar archivos estáticos desde /wwwroot ===
app.UseDefaultFiles(); // Busca automáticamente index.html
app.UseStaticFiles();  // Sirve HTML, CSS, JS, imágenes

// Sin HTTPS redirection (Render usa HTTP)
app.UseAuthorization();
app.MapControllers();

app.Run();
