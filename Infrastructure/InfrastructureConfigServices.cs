using Domain.Repository.Auth;
using Domain.Repository.Plans;
using Domain.Repository.Users;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Mappings.Plans;
using Infrastructure.Repository.Auth;
using Infrastructure.Repository.Plans;
using Infrastructure.Repository.Users;
using Microsoft.Extensions.Configuration;
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
        public static void InstallInfrastructureConfigServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {



            InstallConfiguration(serviceCollection,configuration);
            InstallSeeds(serviceCollection);
            InstallMapping(serviceCollection);
            InstallRepositories(serviceCollection);

        
        }

        private static void InstallConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("BaseUrl").Get<BaseUrl>();
            serviceCollection.AddSingleton<BaseUrl>(baseUrl);

            serviceCollection.AddHttpClient("ApiClient", client => { client.BaseAddress = new Uri(baseUrl.Api); });

            serviceCollection.AddScoped<ClientFactory>();
        }
        private static void InstallSeeds(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SeedsUsers>();
            serviceCollection.AddSingleton<SeedsPlans>();
            serviceCollection.AddSingleton<SeedsPlansContainers>();
            serviceCollection.AddScoped<AuthControl>();
        }

        private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(InfrastructureMappingConfig));
            serviceCollection.AddAutoMapper(typeof(PlansMappingConfig));
            serviceCollection.AddAutoMapper(typeof(PlansRemoteMappingConfig));
            serviceCollection.AddAutoMapper(typeof(InfrastructureRemoteMappingConfig));
        }

        private static void InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlansContainerRepository, PlansContainerRepository>();
            serviceCollection.AddScoped<IPlansRepository,PlansRepository>();
            serviceCollection.AddScoped<IUsersRepository,UsersRepository>();
            serviceCollection.AddScoped<IAuthRepository,AuthRepository>();
        }    
      
    }
}
