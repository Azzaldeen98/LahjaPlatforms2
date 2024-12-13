namespace Domain.Entities.Plans
{
    public class BasicPlan
    {
        public string? Id { get; set; }
        //public string? ContainerId { get; set; }
        public string? ProductName { get; set; }
        public bool? Active { get; set; } = true;
        public List<PlanSubscriptionFeatures>? SubscriptionFeatures { get; set; }
        public List<PlanTechnicalFeatures>? TechnicalFeatures { get; set; }
    }

}
