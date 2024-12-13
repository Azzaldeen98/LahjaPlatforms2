using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans
{
    public class GetAllBasicPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllBasicPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<BasicPlan>>> ExecuteAsync()
        {

            var data = await repository.getAllBasicPlansAsync();

            if (data != null)
            {
                return Result<IEnumerable<BasicPlan>>.Success(data);
            }
            else
            {
                return Result<IEnumerable<BasicPlan>>.Fail();
            }


        }
    }

}
