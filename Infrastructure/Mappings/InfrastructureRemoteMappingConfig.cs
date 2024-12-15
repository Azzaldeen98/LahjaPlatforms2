using Infrastructure.Models.Plans;
using Infrastructure.Nswag;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

            /// Auth
            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>().ReverseMap();
            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();

            /// Plans


            /// Profile
            //CreateMap<ProfileResponseModel, >().ReverseMap();


            /// Payment

        }
    }
}
