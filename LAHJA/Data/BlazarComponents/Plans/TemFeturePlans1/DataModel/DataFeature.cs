 
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans1.Model;

namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans1.DataModel
{
    public class DataFeature
    {
        public List<FeaturesPlansTem1> featureList = new List<FeaturesPlansTem1>
{
    new FeaturesPlansTem1
    {
        Id = "F001",
        ProductName = "Basic Plan",
        ProductId = "P001",
        BillingPeriod = "Monthly",
        NumberRequests = 1000,
        Amount = 9.99,
        Active = true
    },
    new FeaturesPlansTem1
    {
        Id = "F002",
        ProductName = "Standard Plan",
        ProductId = "P002",
        BillingPeriod = "Monthly",
        NumberRequests = 5000,
        Amount = 19.99,
        Active = true
    },
    new FeaturesPlansTem1
    {
        Id = "F003",
        ProductName = "Premium Plan",
        ProductId = "P003",
        BillingPeriod = "Yearly",
        NumberRequests = 50000,
        Amount = 199.99,
        Active = false
    },
    new FeaturesPlansTem1
    {
        Id = "F004",
        ProductName = "Enterprise Plan",
        ProductId = "P004",
        BillingPeriod = "Yearly",
        NumberRequests = 100000,
        Amount = 399.99,
        Active = true
    }
};
    }
}
