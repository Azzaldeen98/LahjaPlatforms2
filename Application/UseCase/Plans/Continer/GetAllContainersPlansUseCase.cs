using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetAllContainersPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllContainersPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<ContainerPlans>>> ExecuteAsync()
        {

            return await repository.getAllContainersPlansAsync();


        }


    }
}
