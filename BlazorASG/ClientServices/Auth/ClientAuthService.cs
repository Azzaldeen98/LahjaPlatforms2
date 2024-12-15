using Application.Services.Auth;
using Application.Services.Plans;
using Application.UseCase.Plans;
using AutoMapper;
using BlazorASG.Data.BlazarComponents.Plans.Category.Model;
using BlazorASG.Nswag;
using Blazorise.Extensions;
using CardShopping.Web.Token;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorASG.ClientServices.Auth
{
    public class ClientAuthService
    {
        private readonly TokenService tokenService;
        private readonly AuthService service;
        private readonly IMapper _mapper;


        public ClientAuthService(AuthService service, IMapper mapper, TokenService tokenService)
        {

            this.service = service;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<Result<Domain.Entities.Auth.Response.LoginResponse>> loginAsync(VitsModel.Auth.LoginRequest request)
        {

            var model = _mapper.Map<Domain.Entities.Auth.Request.LoginRequest>(request);
            var response= await service.loginAsync(model);
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

            var model = _mapper.Map<Domain.Entities.Auth.Request.RegisterRequest>(request);
            return await service.registerAsync(model);

        }

        public async Task<Result<string>> forgetPasswordAsync(string email)
        {
            return await service.forgetPasswordAsync(email);

        }


    }
}
