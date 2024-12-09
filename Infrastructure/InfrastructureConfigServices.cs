using Domain.Repository.Plans;
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
    public static class InfrastructureConfigServices
    {
        public static void InstallInfrastructureConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallRepositories(serviceCollection);
        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(PlansMappingConfig));
        }


        private static void InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlansRepository,PlansRepository>();
        }
    }
}
