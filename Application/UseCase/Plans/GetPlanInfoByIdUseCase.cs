﻿using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetPlanInfoByIdUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlanInfoByIdUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<PlanInfoResponse>> ExecuteAsync(string id)
        {

          return await repository.GetPlanInfoByIdAsync(id);

        }
    }
}
