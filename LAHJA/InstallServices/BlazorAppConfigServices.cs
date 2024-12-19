using Application.Services.Auth;
using Application.Services.Plans;
using Application.UseCase.Plans;
using LAHJA.Mappings;
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
using LAHJA.Data.UI.Templates.Auth;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Data.UI.Templates.Plans;
using LAHJA.Data.UI.Components.Base;

namespace Infrastructure
{
    public static class BlazorAppConfigServices
    {
        public static void InstallBlazorAppConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallServices(serviceCollection);
            InstallHelperServices(serviceCollection);
            InstallTemplates(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddAutoMapper(typeof(BlazorAppMappingConfig));
        }


        private static void InstallHelperServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<RecaptchaService>();
        

        }  
        
        private static void InstallTemplates(this IServiceCollection serviceCollection)
        {



            //serviceCollection.AddScoped < TemplateBase<IBuilderAuthApi<>, IBuilderAuthComponent<DataBuildAuthBase>>();


            //serviceCollection.AddScoped<TemplateBase<IBuilderAuthApi<DataBuildAuthBase>, IBuilderAuthComponent<DataBuildAuthBase>>();

            //serviceCollection.AddScoped<BuilderAuthApiClient>();
            serviceCollection.AddScoped<IBuilderAuthApi<DataBuildAuthBase>, BuilderAuthApiClient>();

           
          
            serviceCollection.AddScoped<IBuilderAuthComponent<DataBuildAuthBase>,BuilderAuthComponent<DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuthShare<ClientAuthService,DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuth>();
            //serviceCollection.AddScoped<TemplatePlans>();

        }
        private static void InstallServices(this IServiceCollection serviceCollection)
        {
     
            serviceCollection.AddScoped<ClientAuthService>();
            serviceCollection.AddScoped<LAHJA.Helpers.Services.AuthService>();
            serviceCollection.AddScoped<PlansClientService>();
            serviceCollection.AddScoped<ClientProfileService>();
           
           
        }
       
    }
}
