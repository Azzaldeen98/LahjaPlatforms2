using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetPlanByIdUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanByIdUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanResponse>> ExecuteAsync(string id)
        {

            return await repository.getPlanByIdAsync(id);



        }
    }
}
