using GerenciamentoAtivos.Service.Interfaces;
using GerenciamentoAtivos.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoAtivos.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra suas regras de negócio aqui dentro do próprio projeto Service
            services.AddScoped<IAtivoService, AtivoService>();
            services.AddScoped<ISegmentoService, SegmentoService>();
            services.AddScoped<IAdministradoraService, AdministradoraService>();

            return services;
        }
    }
}
