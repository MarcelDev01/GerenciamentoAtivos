using GerenciamentoAtivos.Data.Context;
using GerenciamentoAtivos.Data.Repositories;
using GerenciamentoAtivos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Registra o repositório genérico
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// Registra o repositório específicos
builder.Services.AddScoped<IAtivoRepository, AtivoRepository>();
builder.Services.AddScoped<ISegmentoRepository, SegmentoRepository>();
builder.Services.AddScoped<IAdministradoraRepository, AdministradoraRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
