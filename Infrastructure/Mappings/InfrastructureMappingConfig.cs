using Infrastructure.Models.Plans;
using Domain.Entities.User;
using Infrastructure.Models.User;
using Infrastructure.DataSource.Seeds.Models;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;

namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureMappingConfig : AutoMapper.Profile
    {
        public InfrastructureMappingConfig()
        {




            CreateMap<UserModel, RegisterRequestModel>().ReverseMap();
        
            CreateMap<UserModel, UserApp>().ReverseMap();

            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel, UserApp>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>().ReverseMap();
            CreateMap<RegisterResponseModel, RegisterResponse> ().ReverseMap();
            CreateMap<LoginResponseModel, LoginResponse>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();



            CreateMap<LoginResponseModel, UserModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.userId))
            .ReverseMap();

            CreateMap<RegisterRequestModel, RegisterRequest>().ReverseMap();




        }
    }
}
