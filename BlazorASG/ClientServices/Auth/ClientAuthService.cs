using Application.Services.Auth;
using Application.Services.Plans;
using Application.UseCase.Plans;
using AutoMapper;
using BlazorASG.Data.BlazarComponents.Plans.Category.Model;
using BlazorASG.Nswag;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorASG.ClientServices.Auth
{
    public class ClientAuthService
    {
        private readonly AuthService service;
        private readonly IMapper _mapper;


        public ClientAuthService(AuthService service, IMapper mapper)
        {

            this.service = service;
            _mapper = mapper;
        }

        public async Task<Result<Domain.Entities.Auth.Response.LoginResponse>> loginAsync(VitsModel.Auth.LoginRequest request)
        {

            var model = _mapper.Map<Domain.Entities.Auth.Request.LoginRequest>(request);
            return await service.loginAsync(model);
        }

        public async Task<Result<RegisterResponse>> registerAsync(VitsModel.Auth.RegisterRequest request)
        {

            var model = _mapper.Map<Domain.Entities.Auth.Request.RegisterRequest>(request);
            return await service.registerAsync(model);

        }


    }
}
