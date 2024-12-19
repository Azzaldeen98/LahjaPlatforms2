using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlansContainers
    {
      private static List<ContainerPlansModel> db= new List<ContainerPlansModel>();


        public SeedsPlansContainers()
        {

            db = new List<ContainerPlansModel>{
                new ContainerPlansModel
                {
                    Id = "1",
                    Name = "Basic Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "2",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "3",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        }
                    }
                },
                new ContainerPlansModel
                {
                    Id = "2",
                    Name = "Basic Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                    new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        }
                    }
                },
                new ContainerPlansModel
                {
                    Id = "3",
                    Name = "Speshial Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        }
                    }
                },
                new ContainerPlansModel
                {
                    Id = "4",
                    Name = "Company Plan Container",
                    Description = "A container for premium subscription plans.",
                    Active = true,
                    Image = "premium-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "2",
                            Name = "Premium Plan",
                            Description = "A premium subscription plan with more features.",
                            Active = true,
                            Price = 19.99m,
                            IsFixed = true,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 19.99m,
                            ContainerId = "2",
                            TotalBilling = 239.88m,
                            Image = "premium-plan.png",
                            MonthlyPrice = 19.99m,
                            AnnualPrice = 199.99m,
                            WeeklyPrice = 4.99m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "3",
                            Name = "Family Plan",
                            Description = "A subscription plan for families.",
                            Active = true,
                            Price = 29.99m,
                            IsFixed = true,
                            IsPaid = true,
                            Quantity = 5,
                            BillingPeriod = "Monthly",
                            TotalAmount = 29.99m,
                            ContainerId = "2",
                            TotalBilling = 359.88m,
                            Image = "family-plan.png",
                            MonthlyPrice = 29.99m,
                            AnnualPrice = 299.99m,
                            WeeklyPrice = 7.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "4",
                            Name = "Family Plan",
                            Description = "A subscription plan for families.",
                            Active = true,
                            Price = 29.99m,
                            IsFixed = true,
                            IsPaid = true,
                            Quantity = 5,
                            BillingPeriod = "Monthly",
                            TotalAmount = 29.99m,
                            ContainerId = "2",
                            TotalBilling = 359.88m,
                            Image = "family-plan.png",
                            MonthlyPrice = 29.99m,
                            AnnualPrice = 299.99m,
                            WeeklyPrice = 7.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        }
                    }
                }
            };


        }


        public async Task<IEnumerable<PlansContainerModel>?> getAllContainersAsync()
        {

            return new List<PlansContainerModel>{
                new PlansContainerModel
                {
                    Id = "1",
                    Name = "Basic Plan",
                    Description = "This is a basic plan with minimal features.",
                    Price = 19.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "2",
                    Name = "Standard Plan",
                    Description = "This is a standard plan with more features.",
                    Price = 49.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "3",
                    Name = "Premium Plan",
                    Description = "This is a premium plan with all features.",
                    Price = 99.99m,
                    ImageUrl = "/ai-hand.png",


                }
         };
        }

        public async Task<IEnumerable<ContainerPlansModel>?> getAllAsync()
        {
          

            return db;
        }

        public async Task<ContainerPlansModel?> getOneAsync(string containerId)
        {

            return db.FirstOrDefault(x=>x.Id== containerId) ??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getSubscriptionsPlansAsync(string containerId)
        {

            return db.FirstOrDefault(x => x.Id == containerId)?.SubscriptionsPlans??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getAllSubscriptionsPlansAsync()
        {
            var subscriptionPlans = db.Where(x => x.SubscriptionsPlans != null && x.SubscriptionsPlans.Any())
                                      .SelectMany(x => x.SubscriptionsPlans)
                                      .ToList();

            return subscriptionPlans;
        }

        public async Task<List<PlanFeatureModel>?> getSubscriptionsPlansFeaturesAsync(string planId)
        {
            foreach (var item in db)
            {
                var plan = item?.SubscriptionsPlans?.FirstOrDefault(X => X.Id == planId);
                if (plan!=null && plan.Id==planId)
                    return plan.Features??null;
            }
            return  null;
        }



    }
}
