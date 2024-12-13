using BlazorASG.Data.BlazarComponents.Plans.Category.Model;
using BlazorASG.Data.BlazarComponents.Plans.TemFeturePlans1.Model;
using BlazorASG.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using Domain.Entities.Plans;

namespace BlazorASG.Mappings
{
    public class BlazorAppMappingConfig : AutoMapper.Profile
    {

        public BlazorAppMappingConfig()
        {

            CreateMap<PlansContainer, InputCategory>().ReverseMap();
     
          
            CreateMap<Domain.Entities.Auth.Request.LoginRequest, VitsModel.Auth.LoginRequest>().ReverseMap();
            CreateMap<Domain.Entities.Auth.Request.RegisterRequest, VitsModel.Auth.RegisterRequest>().ReverseMap();
            //CreateMap<PlansContainer, InputCategory>().ReverseMap();

            CreateMap<Plan, FeaturesPlansTem1>().ReverseMap();

            CreateMap<BasicPlan,PlansFeture>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src.ProductName))
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ForMember(dest => dest.numberOfServices, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PlanSubscriptionFeatures, Service>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Amount))
                .ReverseMap();
            CreateMap<PlanTechnicalFeatures, NumberOfService>().ReverseMap();
        }
    }
}
