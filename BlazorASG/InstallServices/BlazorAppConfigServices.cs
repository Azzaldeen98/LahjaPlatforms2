using Application.Services.Auth;
using Application.Services.Plans;
using Application.UseCase.Plans;
using BlazorASG.ClientServices.Auth;
using BlazorASG.ClientServices.Plans;
using BlazorASG.Mappings;
using BlazorASG.Token;
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
    public static class BlazorAppConfigServices
    {
        public static void InstallBlazorAppConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddAutoMapper(typeof(BlazorAppMappingConfig));
        }


        private static void InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ClientAuthService>();
            serviceCollection.AddScoped<AuthCheckedService>();
            serviceCollection.AddScoped<ClientPlansService>();
           
           
        }
       
    }
}
