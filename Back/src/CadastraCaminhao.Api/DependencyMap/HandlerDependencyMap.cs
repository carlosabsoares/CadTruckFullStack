using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Handlers;
using CadastraCaminhao.Domain.Handlers.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CadastraCaminhao.Api.DependencyMap
{
    public static class HandlerDependencyMap
    {
        public static void HandlerMap(this IServiceCollection services)
        {
            //Category
            services.AddScoped<IHandler<TruckInsertCommand>, TruckHandler>();
            services.AddScoped<IHandler<TruckDeleteCommand>, TruckHandler>();
            services.AddScoped<IHandler<TruckUpdateCommand>, TruckHandler>();
        }
    }
}
