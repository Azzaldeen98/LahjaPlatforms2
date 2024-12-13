using Application.UseCase.Plans;
using Domain.Entities.Plans;
using Domain.Wrapper;

namespace Application.Services.Plans
{
    public class PlansService
    {
        private readonly GetAllPlansUseCase getAllPlansUseCase;
        private readonly GetAllBasicPlansUseCase getAllBasicPlansUseCase;
        private readonly GetPlanByIdUseCase getPlanByIdUseCase;
        private readonly GetAllPlansContainersUseCase getAllPlansContainersUseCase;

        public PlansService(
            GetAllPlansUseCase getAllPlansUseCase,
            GetPlanByIdUseCase getPlanByIdUseCase,
            GetAllPlansContainersUseCase getAllPlansContainersUseCase,
            GetAllBasicPlansUseCase getAllBasicPlansUseCase)
        {

            this.getAllPlansUseCase = getAllPlansUseCase;
            this.getPlanByIdUseCase = getPlanByIdUseCase;
            this.getAllPlansContainersUseCase = getAllPlansContainersUseCase;
            this.getAllBasicPlansUseCase = getAllBasicPlansUseCase;
        }

        public async Task<Result<IEnumerable<Plan>>> getAllPlansAsync()
        {
            return await getAllPlansUseCase.ExecuteAsync();

        }
        public async Task<Result<IEnumerable<BasicPlan>>> getAllBasicPlansAsync()
        {
            return await getAllBasicPlansUseCase.ExecuteAsync();

        }


        public async Task<Result<IEnumerable<PlansContainer>>> getAllPlansContainersAsync()
        {
            return await getAllPlansContainersUseCase.ExecuteAsync();

        }

        public async Task<Result<Plan>> getPlanByIdAsync(string id)
        {
            return await getPlanByIdUseCase.ExecuteAsync(id);

        }
    }
}
