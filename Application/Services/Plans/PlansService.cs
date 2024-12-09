using Application.UseCase.Plans;
using Domain.Entities.Plans;
using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Plans
{
    public class PlansService
    {
        private readonly GetAllPlansUseCase getAllPlansUseCase;
        private readonly GetPlanByIdUseCase getPlanByIdUseCase;

        public PlansService(GetAllPlansUseCase getAllPlansUseCase, GetPlanByIdUseCase getPlanByIdUseCase)
        {

            this.getAllPlansUseCase = getAllPlansUseCase;
            this.getPlanByIdUseCase = getPlanByIdUseCase;
        }

        public async Task<Result<IEnumerable<Plan>>> getAllPlansAsync()
        {
            return await getAllPlansUseCase.ExecuteAsync();

        }

        public async Task<Result<Plan>> getPlanByIdAsync(string id)
        {
            return await getPlanByIdUseCase.ExecuteAsync(id);

        }
    }
}
