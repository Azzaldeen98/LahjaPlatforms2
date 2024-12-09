using Infrastructure.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlans
    {

        public async Task<IEnumerable<PlanModel>> getAllPlansAsync()
        {
            var result = new List<PlanModel>(){
                new PlanModel
                {
                    Id = "1",
                    ProductName = "Basic Plan",
                    ProductId = "P001",
                    BillingPeriod = "Monthly",
                    NumberRequests = 100,
                    Amount = 19.99,
                    Active = true,
                    Subscriptions = new List<SubscriptionModel>
                    {
                        new SubscriptionModel
                        {
                            Id = "S001",
                            PlanId = "1",
                            Nr = 1,
                            CustomerId = "C001",
                            StartDate = DateTime.Now,
                            Status = "Active",
                            BillingPeriod = "Monthly",
                            CancelAt = null,
                            CancelAtPeriodEnd = false,
                            CanceledAt = null
                        }
                    }
                },
                new PlanModel
                {
                    Id = "2",
                    ProductName = "Standard Plan",
                    ProductId = "P002",
                    BillingPeriod = "Monthly",
                    NumberRequests = 500,
                    Amount = 49.99,
                    Active = true,
                    Subscriptions = new List<SubscriptionModel>
                    {
                        new SubscriptionModel
                        {
                            Id = "S002",
                            PlanId = "2",
                            Nr = 2,
                            CustomerId = "C002",
                            StartDate = DateTime.Now.AddDays(-30),
                            Status = "Active",
                            BillingPeriod = "Monthly",
                            CancelAt = null,
                            CancelAtPeriodEnd = false,
                            CanceledAt = null
                        }
                    }
                },
                new PlanModel
                {
                    Id = "3",
                    ProductName = "Premium Plan",
                    ProductId = "P003",
                    BillingPeriod = "Yearly",
                    NumberRequests = 2000,
                    Amount = 499.99,
                    Active = true,
                    Subscriptions = new List<SubscriptionModel>
                    {
                        new SubscriptionModel
                        {
                            Id = "S003",
                            PlanId = "3",
                            Nr = 3,
                            CustomerId = "C003",
                            StartDate = DateTime.Now.AddDays(-365),
                            Status = "Expired",
                            BillingPeriod = "Yearly",
                            CancelAt = DateTime.Now.AddDays(-10),
                            CancelAtPeriodEnd = true,
                            CanceledAt = DateTime.Now.AddDays(-5)
                        }
                    }
                }

            };

            return result;
        }


        public async Task<PlanModel> getPlanByIdAsync(string id)
        {
            var result = new PlanModel
            {
                Id = "1",
                ProductName = "Basic Plan",
                ProductId = "P001",
                BillingPeriod = "Monthly",
                NumberRequests = 100,
                Amount = 19.99,
                Active = true,
                Subscriptions = new List<SubscriptionModel>
                    {
                        new SubscriptionModel
                        {
                            Id = "S001",
                            PlanId = "1",
                            Nr = 1,
                            CustomerId = "C001",
                            StartDate = DateTime.Now,
                            Status = "Active",
                            BillingPeriod = "Monthly",
                            CancelAt = null,
                            CancelAtPeriodEnd = false,
                            CanceledAt = null
                        }
                    }
            };

            return result;
        }
    }
}
