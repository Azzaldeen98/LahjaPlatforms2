using Domain.ShareData.Base;

namespace Infrastructure.Models.Plans
{
  public  class SubscriptionPlanModel : BaseSubscriptionPlan
    {
        public new ContainerPlansModel? ContainerPlan { get; set; }
        public new List<PlanFeatureModel>? Features { get; set; }

    }






}
