namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model
{
    public class TechnologyService
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<TechnicalService> TechnicalServices { get; set; } = new List<TechnicalService>();
    }
}
