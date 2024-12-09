using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Nswag;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

     
            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>().ReverseMap();
            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();


        }
    }
}
