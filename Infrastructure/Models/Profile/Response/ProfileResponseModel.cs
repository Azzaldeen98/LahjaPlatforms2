using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using Shared.BaseModels;

namespace Infrastructure.Models.Profile.Response
{
    public class ProfileResponseModel : BaseProfile
    {
        public IEnumerable<PlanSubscriptionResponseModel>?  PlanSubscriptions { get; set; }

    }
}
