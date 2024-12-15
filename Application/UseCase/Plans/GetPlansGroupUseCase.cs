﻿using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetPlansGroupUseCase
    {
        private readonly IPlansRepository repository;
        public GetPlansGroupUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlansGroupResponse>>> ExecuteAsync()
        {

            return await repository.getPlansGroupAsync();

        }
    }

}
