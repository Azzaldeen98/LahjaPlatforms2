
using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Repository.Auth;
using Domain.Wrapper;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Auth;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Shared.Settings;

namespace Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SeedsUsers seedsUsers;
        private readonly AuthControl authControl;
        private readonly AuthApiClient authApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public AuthRepository(
            IMapper mapper,
            ApplicationModeService appModeService,
            AuthControl authControl,
            AuthApiClient authApiClient,
            SeedsUsers seedsUsers)
        {

            _mapper = mapper;
            this.appModeService = appModeService;
            this.authControl = authControl;
            this.authApiClient = authApiClient;
            this.seedsUsers = seedsUsers;
        }



        public async Task<Result<LoginResponse>> loginAsync(LoginRequest request)
        {

            var model = _mapper.Map<LoginRequestModel>(request);

            var response = await authControl.loginAsync(model);

            if (response.Succeeded)
            {
                var res = _mapper.Map<LoginResponse>(response.Data);

                return Result<LoginResponse>.Success(res);
               
            }
            else
            {
                return Result<LoginResponse>.Fail(response.Messages);
            }


        }
             public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest request)
            {
                    var model = _mapper.Map<RegisterRequestModel>(request);

                    var response=await authControl.registerAsync(model);

                    //return _mapper.Map<RegisterResponse>(response);

                    if (response.Succeeded)
                    {
                        var res = _mapper.Map<RegisterResponse>(response.Data);
                        return Result<RegisterResponse>.Success(res);
       
                    }
                    else
                    {
                        return Result<RegisterResponse>.Fail(response.Messages);
                    }


        }




    }
}
