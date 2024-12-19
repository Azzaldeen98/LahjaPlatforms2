
using Domain.ShareData.Base;
using Domain.ShareData.Base.Auth;
using Infrastructure.Models.Plans;
using Infrastructure.Nswag;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

            /// Auth
            /// 
            CreateMap<AccessTokenResponse, AccessTokenResponseModel>().ReverseMap();
            CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            //CreateMap<ConfirmationEmailModel, ConfirmationEmailRequest>().ReverseMap();
            CreateMap<ResendConfirmationEmailRequest, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
         

            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>()
                 .ForMember(dest => dest.FirsName, opt => opt.MapFrom(src => "string"))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => "string"))
                 .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.password))
                 .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "string"))
                .ReverseMap();

            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();
            CreateMap<PlansGroupModel, PlanGrouping>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
                .ForMember(dest => dest.Services, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();


            /// Plans


            /// Profile
            //CreateMap<ProfileResponseModel, >().ReverseMap();


            /// Payment

        }
    }
}
