namespace BlazorASG.Application_Layer.Model_Share
{
    public class BaseUrls
    {
        public string Api { get; set; }
        public string Auth { get; set; }
        public string Web { get; set; }
    }

    public  class FlagCount
    {
        public int Count { set; get; }
        public bool IsFlag { get; set; }
    }
    public class menu
    {
        public int id { get; set; }
        public string Name { get; set;}
    }

    public enum OpCard
    {
        Card=0,
        Image=1
    }
    public enum OperationTypeCard
    {
        New,
        Edit,
        purchase
    }
}


