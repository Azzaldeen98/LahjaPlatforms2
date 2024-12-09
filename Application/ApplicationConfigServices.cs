using Application.Services.Plans;
using Application.UseCase.Plans;
using Infrastructure.Mappings.Plans;
using Infrastructure.Repository.Plans;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ApplicationConfigServices
    {
        public static void InstallApplicationConfigServices(this IServiceCollection serviceCollection)
        {

            //InstallMapping(serviceCollection);
            InstallUsaCases(serviceCollection);
            InstallServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddAutoMapper(typeof(PlansMappingConfig));
        }

        private static void InstallUsaCases(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<GetAllPlansUseCase>();
            serviceCollection.AddScoped<GetPlanByIdUseCase>();
        }

        private static void InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<PlansService>();
        }
       
    }
}
