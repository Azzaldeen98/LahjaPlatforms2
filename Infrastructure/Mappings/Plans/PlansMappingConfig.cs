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

namespace Infrastructure.Mappings.Plans
{

    public class PlansMappingConfig : AutoMapper.Profile
    {
        public PlansMappingConfig()
        {




            CreateMap<PlanModel, Plan>().ReverseMap();
            CreateMap<SubscriptionModel, Subscription>().ReverseMap();

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
