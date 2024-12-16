using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans1.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using Domain.Entities.Plans.Response;

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
        }
    }
}
