using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans1.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using Domain.Entities.Plans.Response;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model;
using LAHJA.Data.UI.Components.Base;
using Domain.Entities.Auth.Request;

namespace LAHJA.Mappings
{
    public class BlazorAppMappingConfig : AutoMapper.Profile
    {

        public BlazorAppMappingConfig()
        {

            CreateMap<PlansContainerResponse, InputCategory>().ReverseMap();
     
          
            CreateMap<Domain.Entities.Auth.Request.LoginRequest, VitsModel.Auth.LoginRequest>().ReverseMap();
            CreateMap<Domain.Entities.Auth.Request.RegisterRequest, VitsModel.Auth.RegisterRequest>().ReverseMap();
            //CreateMap<PlansContainer, InputCategory>().ReverseMap();

            CreateMap<PlanResponse, FeaturesPlansTem1>().ReverseMap();

            CreateMap<PlansGroupResponse,PlansFeture>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src.ProductName))
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.numberOfServices, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PlanSubscriptionFeaturesResponse, Service>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Amount))
                .ReverseMap();
            CreateMap<PlanTechnicalFeaturesResponse, NumberOfService>().ReverseMap();

            CreateMap<PlansGroupResponse, PlanInfoResponse>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
           .ReverseMap();


            CreateMap<PlanSubscriptionFeaturesResponse, PlanTechnicalServiceResponse>()
                .ForMember(dest => dest.TechnicalServiceFeatures, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanTechnicalFeaturesResponse, PlanQuantitativeFeatureResponse>().ReverseMap();




            CreateMap<PlanInfoResponse, PlanInfo>()
                .ForMember(dest => dest.PlanDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TechnologyServices, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceDetailsList, opt => opt.Ignore())
                .ReverseMap();          
            
            
            CreateMap<PlanTechnicalServiceResponse, TechnologyService>()
                .ForMember(dest => dest.TechnicalServices, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanQuantitativeFeatureResponse, DigitalService>()
             .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
             //.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ReverseMap();
            
            
            CreateMap<DataBuildAuthBase, LoginRequest>().ReverseMap();

            CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ForgetPasswordRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResendConfirmationEmail>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResetPasswordRequest>()
                 .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
            CreateMap<DataBuildAuthBase, ConfirmationEmail>()
                .ForMember(dest => dest.ChangedEmail, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            //CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();


            CreateMap<ContainerPlans, InputCategory>()
      
           .ReverseMap();

            //CreateMap<TechnologyService, NumberOfService>().ReverseMap();
        }
    }
}
