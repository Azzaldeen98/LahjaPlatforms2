using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetAllPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlanResponse>>> ExecuteAsync()
        {

            return await repository.getAllPlansAsync();

        }
    }  

}
