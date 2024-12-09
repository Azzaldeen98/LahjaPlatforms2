using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Shared.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetPlanByIdUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanByIdUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<Plan>> ExecuteAsync(string id)
        {

            var data = await repository.getPlanByIdAsync(id);

            if (data != null)
            {
                return Result<Plan>.Success(data);
            }
            else
            {
                return Result<Plan>.Fail();
            }


        }
    }
}
