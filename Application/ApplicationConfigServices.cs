using Application.Services.Auth;
using Application.Services.Plans;
using Application.Services.Profile;
using Application.UseCase;
using Application.UseCase.Auth;
using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
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

            InstallMapping(serviceCollection);
            InstallUsaCases(serviceCollection);
            InstallServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMappingConfig));
        }

        private static void InstallUsaCases(this IServiceCollection serviceCollection)
        {
            /// Auth
            serviceCollection.AddScoped<LoginUseCase>();
            serviceCollection.AddScoped<RegisterUseCase>();
            serviceCollection.AddScoped<ForgetPasswordUseCase>();
            serviceCollection.AddScoped<ResetPasswordUseCase>();
            serviceCollection.AddScoped<ConfirmationEmailUseCase>();
            serviceCollection.AddScoped<ReSendConfirmationEmailUseCase>();
            serviceCollection.AddScoped<RefreshTokinUseCase>();
            serviceCollection.AddScoped<LogoutUseCase>();

            /// Plans
            serviceCollection.AddScoped<GetAllContainersPlansUseCase>();
            serviceCollection.AddScoped<GetPlansGroupUseCase>();
            serviceCollection.AddScoped<GetAllPlansUseCase>();
            serviceCollection.AddScoped<GetPlanByIdUseCase>();
            serviceCollection.AddScoped<GetPlanInfoByIdUseCase>();
            serviceCollection.AddScoped<GetAllPlansContainersUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlansUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlanFeaturesUseCase>();
            serviceCollection.AddScoped<GetAllSubscriptionsPlansUseCase>();


            /// Profile
            serviceCollection.AddScoped<GetProfileUseCase>();

            /// Payment
            //serviceCollection.AddScoped<GetPaymentUseCase>();


        }

        private static void InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<PlansService>();
            serviceCollection.AddScoped<WebAuthService>();
            serviceCollection.AddScoped<ProfileService>();
            //serviceCollection.AddScoped<PaymentService>();
        }
       
    }
}
