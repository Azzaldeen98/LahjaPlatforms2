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
using Application.UseCase.Auth;

namespace Application.Services.Auth
{
    public class WebAuthService
    {
        private readonly LoginUseCase loginUseCase;
        private readonly RegisterUseCase registerUseCase;
        private readonly ForgetPasswordUseCase forgetPasswordUseCase;

        public WebAuthService(LoginUseCase loginUseCase, RegisterUseCase registerUseCase, ForgetPasswordUseCase forgetPasswordUseCase)
        {


            this.loginUseCase = loginUseCase;
            this.registerUseCase = registerUseCase;
            this.forgetPasswordUseCase = forgetPasswordUseCase;
        }

        public async Task<Result<LoginResponse>> loginAsync(LoginRequest request)
        {
            return await loginUseCase.ExecuteAsync(request);

        }

        public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest request)
        {
            return await registerUseCase.ExecuteAsync(request);
                
            

        }
        public async Task<Result<string>> forgetPasswordAsync(string email)
        {
            return await forgetPasswordUseCase.ExecuteAsync(email);
                
            

        }

    }
}
