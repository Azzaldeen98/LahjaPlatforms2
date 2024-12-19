using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;

namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model
{
    public class PlanInfo : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdService { get; set; }
        public string PlanDescription { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public List<TechnologyService> TechnologyServices { get; set; } = new List<TechnologyService>();
        public List<DigitalService> ServiceDetailsList { get; set; } = new List<DigitalService>();
    }



    public class FeaturePlanInfo
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; } = true;
        public decimal Price { get; set; } = 2;
        public bool IsFixed { get; set; } = true;

        public bool? IsPaid { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice => Quantity * Price;
    }
    public class SubscriptionPlanInfo: FeaturePlanInfo
    {

       
        public string? BillingPeriod { get; set; }
        public decimal? TotalBilling { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public string? Token { get; set; }
        public string? Processor { get; set; }
        public string? ConnectionType { get; set; }
        public string? AbsolutePath { get; set; }
        public string? Image { get; set; }
        public List<string>? Images { get; set; }
        public string? ContainerId { get; set; }

        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        public decimal? MonthlyPrice { get; set; }
        public decimal? AnnualPrice { get; set; }
        public decimal? WeeklyPrice { get; set; }


        public new List<FeaturePlanInfo> Features { get; set; }

    }

 
}
