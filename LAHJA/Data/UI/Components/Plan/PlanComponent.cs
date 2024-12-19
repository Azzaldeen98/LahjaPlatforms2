namespace LAHJA.Data.UI.Components.Plan
{
   
    public enum PlanType
    {
        Basic,
        Premium,
        Enterprise,
        Custom
    }
    public enum DiscountType
    {
        Percentage,
        Fixed
    }
    public class Discount
    {
        public string Description { get; set; }


        public decimal Value { get; set; }

        public DiscountType Type { get; set; }

        public Discount(DiscountType type, decimal value, string description)
        {
            Type = type;
            Value = value;
            Description = description;
        }


        
        public decimal GetDiscountAmount(decimal totalPrice)
        {
            return Type switch
            {
                DiscountType.Percentage => totalPrice * (Value / 100),
                DiscountType.Fixed => Value,
                _ => 0
            };
        }
    }

    public class Digital
    {
        public string Name { get; set; }   
        public bool IsEnabled { get; set; }
        public bool Status { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

    }
    public class Customer
    {
        public Guid Id { get; set; }  
        public string FullName { get; set; }  
        public string Email { get; set; } 
    }

    public enum PlanStatus
    {
        Active,        
        Inactive,     
        Expired,      
        Suspended,     
        Pending       
    }
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceImpact { get; set; }
        public bool IsEnabled { get; set; }
        public bool Status { get; set; }
    }
        public class PlanComponent
        {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string? BillingPeriod
        {
            get; set;
        }

        public PlanType Type { get; set; }
        public decimal BasePrice { get; set; }
 
        public List<Discount> Discounts { get; private set; }
        public List<Feature> Features { get; private set; }
        public List<Digital> Addons { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public Customer Customer { get; set; }
        public PlanStatus Status { get; private set; }
        
    }




}