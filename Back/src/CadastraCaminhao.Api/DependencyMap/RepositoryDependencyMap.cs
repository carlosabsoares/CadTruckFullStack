using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
