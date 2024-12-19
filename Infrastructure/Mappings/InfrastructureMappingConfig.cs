using Infrastructure.Models.Plans;
using Domain.Entities.User;
using Infrastructure.Models.User;
using Infrastructure.DataSource.Seeds.Models;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;
using Infrastructure.Models.Profile.Request;
using Infrastructure.Models.Profile.Response;
using Domain.Entities.Profile;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base.Auth;
using Infrastructure.Models.Auth.Response;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureMappingConfig : AutoMapper.Profile
    {
        public InfrastructureMappingConfig()
        {



            /// Auth
            CreateMap<UserModel, RegisterRequestModel>().ReverseMap();
            CreateMap<UserModel, UserApp>().ReverseMap();
            CreateMap<LoginRequestModel, Domain.Entities.Auth.Request.LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel, UserApp>().ReverseMap();
            CreateMap<RegisterRequestModel, Domain.Entities.Auth.Request.RegisterRequest>().ReverseMap();
            CreateMap<RegisterResponseModel, RegisterResponse> ().ReverseMap();
            CreateMap<LoginResponseModel, LoginResponse>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<LoginResponseModel, UserModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.userId))
            .ReverseMap();
            CreateMap<RegisterRequestModel, Domain.Entities.Auth.Request.RegisterRequest>().ReverseMap();


            CreateMap<AccessTokenResponseModel, AccessTokenResponse>().ReverseMap();
            CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            CreateMap<ConfirmationEmailModel, ConfirmationEmail>().ReverseMap();
            CreateMap<ResendConfirmationEmail, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
            CreateMap<ForgetPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();
            CreateMap<ForgetPasswordResponse, ForgetPasswordResponseModel>().ReverseMap();
            /// Plans



            /// Profile 
            CreateMap<ProfileResponseModel, UserApp>().ReverseMap();

            /// Payment




        }
    }
}
