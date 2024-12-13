using Domain.ShareData.Base;

namespace Domain.Entities.Plans
{
    public class PlanSubscriptionFeatures: BaseSubscriptionFeatures
    {
        public string? Status { get; set; } = "Active";
        public string? Name { get; set; }
        public string? Description { get; set; }

    }

}
