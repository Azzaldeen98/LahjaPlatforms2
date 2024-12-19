using Domain.ShareData.Base;

namespace Infrastructure.Models.Plans
{

    public class ContainerPlansModel : BaseContainerPlans
    {
        public new List<SubscriptionPlanModel>? SubscriptionsPlans { get; set; }
    }






}
