using HNomi.Repositories;
using HNomi.RepositoriesContracts;
using HNomi.Services;
using HNomi.ServicesContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Cross
{
    public static class IoCRegister
    {

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterServices(services);

            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITipoNominaService, TipoNominaService>();
            services.AddTransient<IDetallesTipoNominaService, DetallesTipoNominaService>();
            services.AddTransient<IImpuestosService, ImpuestosService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<ITipoNominaRepository, TipoNominaRepository>();
            services.AddTransient<IDetallesTipoNominaRepository, DetallesTipoNominaRepository>();
            services.AddTransient<IImpuestosRepository, ImpuestosRepository>();

            return services;
        }    

    }
}
