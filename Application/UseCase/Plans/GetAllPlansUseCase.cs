using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Plans
{
    public class GetAllPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllPlansUseCase(IPlansRepository repository) {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<Plan>>> ExecuteAsync(){

           var data=await repository.getAllPlansAsync();

            if (data != null)
            {
                return Result<IEnumerable<Plan>>.Success(data);
            }
            else
            {
               return  Result<IEnumerable<Plan>>.Fail();
            }

           
        }
    }
}
