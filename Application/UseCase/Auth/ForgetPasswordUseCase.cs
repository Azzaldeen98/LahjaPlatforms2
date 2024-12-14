using Domain.Repository.Auth;
using Domain.Wrapper;
using Domain.Entities.Auth.Request;

namespace Application.UseCase.Auth
{
    public class ForgetPasswordUseCase
    {
        private readonly IAuthRepository repository;
        public ForgetPasswordUseCase(IAuthRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<string>> ExecuteAsync(string  email)
        {

            var data = await repository.forgetPasswordAsync(email);
            return  data;

        }
    }
}
