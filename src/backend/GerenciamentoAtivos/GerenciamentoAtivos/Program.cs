using GerenciamentoAtivos.Data.Context;
using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using GerenciamentoAtivos.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:3000") // Portas padrão do Vite/Vue
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Registra o repositório genérico
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// Registra o repositório específicos
builder.Services.AddScoped<IAtivoRepository, AtivoRepository>();
builder.Services.AddScoped<ISegmentoRepository, SegmentoRepository>();
builder.Services.AddScoped<IAdministradoraRepository, AdministradoraRepository>();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        // Aponta para o JSON gerado pelo OpenAPI nativo do .NET 9
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();