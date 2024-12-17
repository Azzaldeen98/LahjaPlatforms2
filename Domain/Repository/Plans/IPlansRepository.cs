using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Plans
{
    public interface IPlansRepository
    {
        public Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync();
        public Task<Result<PlanResponse>> getPlanByIdAsync(string id);
        public Task<Result<PlanInfoResponse>> GetPlanInfoByIdAsync(string id);
        public Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync();
        public Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync();

    }

}
