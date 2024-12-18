namespace Domain.ShareData.Base
{


    //public class BasePricingFeature : BaseFeature
    //{
    //    public decimal Price { get; set; }

    //}
    //public class QuantitativeFeature : BaseQuantitativeFeature
    //{


    //}


    public class BasePlanFeature : BaseQuantitativeFeature
    {

        public decimal TotalAmount { get; set; } = 0;
    }

}
