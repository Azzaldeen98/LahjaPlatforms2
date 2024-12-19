using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class GetAllSubscriptionsPlansUseCase
    {
        private readonly IPlansRepository repository;
        public GetAllSubscriptionsPlansUseCase(IPlansRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<IEnumerable<SubscriptionPlan>>> ExecuteAsync(int skip = 0, int take = 0)
        {

            return await repository.getAllSubscriptionsPlansAsync();

        }
    }

}
