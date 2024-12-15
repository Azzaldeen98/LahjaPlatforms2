using Domain.Repository.Auth;
using Domain.Repository.Plans;
using Domain.Repository.Profile;
using Domain.Repository.Users;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Auth;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.ApiClient.Profile;
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
            InstallApiClients(serviceCollection);
            InstallSeeds(serviceCollection);
            InstallMapping(serviceCollection);
            InstallRepositories(serviceCollection);
            InstallControls(serviceCollection);

        
        }

        private static void InstallConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("BaseUrl").Get<BaseUrl>();
            serviceCollection.AddSingleton<BaseUrl>(baseUrl);

            serviceCollection.AddHttpClient("ApiClient", client => { client.BaseAddress = new Uri(baseUrl.Api); });

            serviceCollection.AddScoped<ClientFactory>();
            //serviceCollection.AddScoped<ITokenProvider, TokenProvider>();

        }
        private static void InstallControls(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<AuthControl>();
        }
        private static void InstallApiClients(this IServiceCollection serviceCollection)
        {
          

            serviceCollection.AddScoped<BaseApiClient>();
            serviceCollection.AddScoped<AuthApiClient>();
            serviceCollection.AddScoped<PlansApiClient>();
            serviceCollection.AddScoped<ProfileApiClient>();
        }
        private static void InstallSeeds(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SeedsProfile>();
            serviceCollection.AddSingleton<SeedsUsers>();
            serviceCollection.AddSingleton<SeedsPlans>();
            serviceCollection.AddSingleton<SeedsPlansContainers>();
           

       
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
            serviceCollection.AddScoped<IPlansRepository,BaseRepository>();
            serviceCollection.AddScoped<IUsersRepository,UsersRepository>();
            serviceCollection.AddScoped<IAuthRepository,AuthRepository>();
            serviceCollection.AddScoped<IProfileRepository, ProfileRepository>();
        }    
      
    }
}
