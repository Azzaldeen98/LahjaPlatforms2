using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;

namespace Domain.Repository.Auth
{
    public  interface  IAuthRepository
    {

        public Task<Result<LoginResponse>> loginAsync(LoginRequest model);
        public Task<Result<RegisterResponse>> registerAsync(RegisterRequest model);
    }
}
