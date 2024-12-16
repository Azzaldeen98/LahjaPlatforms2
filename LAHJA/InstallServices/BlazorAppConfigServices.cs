using Application.Services.Auth;
using Application.Services.Plans;
using Application.UseCase.Plans;
using LAHJA.HelperServices;
using LAHJA.Mappings;
using LAHJA.Token;
using Infrastructure.Mappings.Plans;
using Infrastructure.Repository.Plans;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.ApplicationLayer.Profile;

namespace Infrastructure
{
    public static class BlazorAppConfigServices
    {
        public static void InstallBlazorAppConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallServices(serviceCollection);
            InstallHelperServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddAutoMapper(typeof(BlazorAppMappingConfig));
        }


        private static void InstallHelperServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<RecaptchaService>();
        

        }
        private static void InstallServices(this IServiceCollection serviceCollection)
        {
     
            serviceCollection.AddScoped<ClientAuthService>();
            serviceCollection.AddScoped<AuthCheckedService>();
            serviceCollection.AddScoped<ClientPlansService>();
            serviceCollection.AddScoped<ClientProfileService>();
           
           
        }
       
    }
}
