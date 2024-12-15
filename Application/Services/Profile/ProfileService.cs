using Application.UseCase.Plans;
using Domain.Entities.Profile;
using Domain.Wrapper;

namespace Application.Services.Profile
{
    public class ProfileService
    {
        private readonly GetProfileUseCase getProfileUseCase;


        public ProfileService(GetProfileUseCase getProfileUseCase)
        {
            this.getProfileUseCase = getProfileUseCase;
        }

        public async Task<Result<ProfileResponse>> getProfileAsync()
        {
            return await getProfileUseCase.ExecuteAsync();

        }




    }
}
