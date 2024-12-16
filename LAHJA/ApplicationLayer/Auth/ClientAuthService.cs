
using Application.Services.Auth;
using AutoMapper;
using Blazorise.Extensions;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using LAHJA.Helpers.Services;


namespace LAHJA.ApplicationLayer.Auth
{
    public class ClientAuthService
    {
        private readonly TokenService tokenService;
        private readonly WebAuthService service;

        private readonly IMapper _mapper;


        public ClientAuthService(WebAuthService service, IMapper mapper, TokenService tokenService)
        {

            this.service = service;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> loginAsync(VitsModel.Auth.LoginRequest request)
        {

            var model = _mapper.Map<LoginRequest>(request);
            var response = await service.loginAsync(model);
            if (response.Succeeded)
            {
                await tokenService.SaveAllTokensAsync(response.Data.accessToken,
                                                    response.Data.refreshToken,
                                                    response.Data.expiresIn,
                                                    response.Data.tokenType);
            }


            return response;
        }

        public async Task<Result<RegisterResponse>> registerAsync(VitsModel.Auth.RegisterRequest request)
        {

            var model = _mapper.Map<RegisterRequest>(request);
            return await service.registerAsync(model);

        }

        public async Task<Result<string>> forgetPasswordAsync(string email)
        {
            return await service.forgetPasswordAsync(email);

        }


    }
}
