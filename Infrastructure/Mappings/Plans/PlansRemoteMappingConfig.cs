using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using AutoMapper;
using Infrastructure.Models.Plans;
using Domain.Entities.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Nswag;

namespace Infrastructure.Mappings.Plans
{

    public class PlansRemoteMappingConfig : AutoMapper.Profile
    {
        public PlansRemoteMappingConfig()
        {


            CreateMap<PlanResponseModel, PlanResponse>().ReverseMap();
            CreateMap<PlanServicesResponse, PlanFeatureModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ServiceId))
            .ReverseMap();

            CreateMap<PlanResponse,SubscriptionPlanModel> ()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.PlanServices))
            .ReverseMap();

            CreateMap<PlanServicesResponse, SubscriptionPlanModel> ()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src=>src.ServiceId))
                .ForMember(dest => dest.Features, opt => opt.Ignore())
            .ReverseMap();        
            
            CreateMap<PlanResponse, ContainerPlansModel > ()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src=>src.ProductId))
                .ForMember(dest => dest.SubscriptionsPlans, opt => opt.MapFrom(src=>src.PlanServices))
            .ReverseMap();

            CreateMap<PlanResponseModel, PlanResponse>()
           .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
           //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
           .ForMember(dest => dest.PlanServices, opt => opt.Ignore())
           .ReverseMap();


            CreateMap<PlanSubscriptionResponseModel, PlanServicesResponse>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<ContainerPlansModel, PlanServicesResponse>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ReverseMap();

            //CreateMap<PlanModel, Plan>().ReverseMap();
            //CreateMap<PlansContainerModel, PlansContainer>().ReverseMap();
            //CreateMap<SubscriptionModel, Subscription>().ReverseMap();

            //    .ForMember(dest => dest.likes, opt => opt.MapFrom(src => src.likes != null ? src.likes.Count : 0))
            //.ReverseMap();

            //CreateMap<DailyCareTimesUpdate, DailyCareTimes>()
            //       .ForMember(dest => dest.time, opt => opt.MapFrom(src => Helper.ConvertToTimeSpan(src.time)))
            //       .ReverseMap();
            //CreateMap<JoinBroadcastLive, IndexJoinBroadcastLive>()
            //         .ForMember(dest => dest.user, opt => opt.Ignore())
            //.ReverseMap();



        }
    }
}
