using CadastraCaminhao.Domain.Repositories;
using CadastraCaminhao.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastraCaminhao.Api.DependencyMap
{
    public static class RepositoryDependencyMap
    {
        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddScoped<IContextRepository, ContextRepository>();
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}