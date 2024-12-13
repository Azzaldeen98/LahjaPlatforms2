using Domain.Entities.Plans;

namespace Domain.Repository.Plans
{
    public interface IPlansContainerRepository
    {
        public Task<IEnumerable<PlansContainer>> getAllPlansContainerAsync();
    }
}
