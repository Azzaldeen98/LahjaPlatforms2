using Application.UseCase.Plans;
using Domain.Entities.Plans;
using Infrastructure.Models.Plans;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;

namespace Application.Services.Auth
{
    public class AuthService
    {
        private readonly LoginUseCase loginUseCase;
        private readonly RegisterUseCase registerUseCase;

        public AuthService(LoginUseCase loginUseCase, RegisterUseCase registerUseCase)
        {


            this.loginUseCase = loginUseCase;
            this.registerUseCase = registerUseCase;
        }

        public async Task<Result<LoginResponse>> loginAsync(string email,string password)
        {
            return await loginUseCase.ExecuteAsync(new LoginRequest { email=email,password=password});

        }

        public async Task<Result<RegisterResponse>> registerAsync(RegisterRequestEntity request)
        {
            return await registerUseCase.ExecuteAsync(request);
                
            

        }

    }
}
