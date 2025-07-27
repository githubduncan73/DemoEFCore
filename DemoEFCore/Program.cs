using DemoEFCore.Data;
using DemoEFCore.Repositories;
using DemoEFCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson; // 👈 Asegúrate de tener este `using` si no se agrega solo
using Microsoft.EntityFrameworkCore;
using DemoEFCore.Middlewares; // 👈 Asegúrate de que esto esté

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👇 Aquí agregamos NewtonsoftJson al pipeline
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Esto se agrega por: Tema: Aplicar patrón Repository y DTOs en EF Core
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

////Esto se agrega para que funcione AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Esto se agrega para usar la capa de servicios
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Middleware de errores personalizado
app.UseMiddleware<ExceptionMiddleware>();

// Configuración del entorno
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
