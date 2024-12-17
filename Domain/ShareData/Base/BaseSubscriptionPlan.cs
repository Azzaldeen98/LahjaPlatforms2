namespace Domain.ShareData.Base
{
    public class BaseSubscriptionPlan : BasePlanFeature
    {

        public string? BillingPeriod { get; set; }
        public decimal? TotalBilling { get; set; }
        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        public decimal? MonthlyPrice { get; set; }
        public decimal? AnnualPrice { get; set; }
        public decimal? WeeklyPrice { get; set; }

    }







}
