using Domain.Entities.Profile;
using Domain.Wrapper;

namespace Domain.Repository.Profile;

public interface IProfileRepository
{
    public Task<Result<ProfileResponse>> getProfileAsync();
}
