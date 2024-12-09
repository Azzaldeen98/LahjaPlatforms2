namespace Infrastructure.Models.Plans
{
    public class SubscriptionModel
    {


        public string? Id { get; set; }
        public string? PlanId { get; set; }
        public long? Nr { get; set; }
        public string? CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public string? Status { get; set; }
        public string? BillingPeriod { get; set; }
        public DateTime? CancelAt { get; set; }
        public bool CancelAtPeriodEnd { get; set; }
        public DateTime? CanceledAt { get; set; }
        //public PlanModel? Plan { get; set; }
        //public UserModel? User { get; set; }

    }


}
