namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model
{
    public class Service
    {


        public string? Id { get; set; } = "";
        public string? IdPlansFeture { get; set; } = "2";
        public string? Name { get; set; } = "Name";
        public decimal Price { get; set; } = 10;
        public string? Description { get; set; } = "descript";
        public string? Status { get; set; } = "Active";
        public List<string>? listt { get; set; } = new List<string>() {"value - 10" };

    }





    public  class NumberOfService
    {
        public string? Id { get; set; } = "";
        public string? IdPlansFeture { get; set; } = "3";
        public int Count { get; set; } = 0;
        public decimal Price { get; set; } = 20;
        public string? Description { get; set; } = "descript";
        public string? Status { get; set; } = "Active";
        public string? Name { get; set; } = "Name";


    }

public class PlansFeture
    {

     
        public string Id { get; set; } = "";
        public string IdCategory { get; set; } = "";
        public string Description { get; set; } = "Description";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "Active";
        public decimal Price { get; set; } = 100;
        public List<Service>? Services { get; set; }
        public List<NumberOfService>? numberOfServices { get; set; }

    }

   
    

}
