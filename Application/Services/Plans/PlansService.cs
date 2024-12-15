using Application.UseCase.Plans;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class PlansService
    {
        private readonly GetAllPlansUseCase getAllPlansUseCase;
        private readonly GetPlansGroupUseCase getPlansGroupUseCase;
        private readonly GetPlanByIdUseCase getPlanByIdUseCase;
        private readonly GetAllPlansContainersUseCase getAllPlansContainersUseCase;

        public PlansService(
            GetAllPlansUseCase getAllPlansUseCase,
            GetPlanByIdUseCase getPlanByIdUseCase,
            GetAllPlansContainersUseCase getAllPlansContainersUseCase,
            GetPlansGroupUseCase getPlansGroupUseCase)
        {

            this.getAllPlansUseCase = getAllPlansUseCase;
            this.getPlanByIdUseCase = getPlanByIdUseCase;
            this.getAllPlansContainersUseCase = getAllPlansContainersUseCase;
            this.getPlansGroupUseCase = getPlansGroupUseCase;
        }

        public async Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync()
        {
            return await getAllPlansUseCase.ExecuteAsync();

        }
      


        public async Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainersAsync()
        {
            return await getAllPlansContainersUseCase.ExecuteAsync();

        } 
        public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync()
        {
            return await getPlansGroupUseCase.ExecuteAsync();

        }

        public async Task<Result<PlanResponse>> getPlanByIdAsync(string id)
        {
            return await getPlanByIdUseCase.ExecuteAsync(id);

        }
    } 
}
