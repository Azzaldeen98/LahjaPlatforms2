namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model
{
    public class BaseEntity
    {

    }
    public class PlanInfo : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdService { get; set; }
        public string PlanDescription { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<TechnologyService> TechnologyServices { get; set; } = new List<TechnologyService>();
        public List<DigitalService> ServiceDetailsList { get; set; } = new List<DigitalService>();
    }

    public class TechnologyService
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TechnicalService> TechnicalServices { get; set; } = new List<TechnicalService>();
    }

    public class TechnicalService
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }

    public class DigitalService
    {
        public string ServiceType { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
