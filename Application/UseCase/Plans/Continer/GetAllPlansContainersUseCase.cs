using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetAllPlansContainersUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllPlansContainersUseCase(IPlansRepository repository) {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<PlansContainer>>> ExecuteAsync(){

           var data=await repository.getAllPlansContainerAsync();

            if (data != null)
            {
                return Result<IEnumerable<PlansContainer>>.Success(data);
            }
            else
            {
               return  Result<IEnumerable<PlansContainer>>.Fail();
            }

           
        }
    }
}
