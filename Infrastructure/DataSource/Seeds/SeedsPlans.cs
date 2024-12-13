﻿using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlans
    {
      private static List<PlanModel> db= new List<PlanModel>();
      private static List<BasicPlanModel> basicDB= new List<BasicPlanModel>();


        public SeedsPlans()
        {
            db.AddRange(new List<PlanModel>(){
                new PlanModel
                {
                    Id = "1",
                    ProductName = "Basic Plan",
                    ProductId = "P001",
                    BillingPeriod = "Monthly",
                    NumberRequests = 100,
                    Amount = 19.99,
                    Active = true,
                    Subscriptions = new List<PlanSubscriptionModel>
                    {
                        new PlanSubscriptionModel
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
                    Subscriptions = new List<PlanSubscriptionModel>
                    {
                        new PlanSubscriptionModel
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
                    Subscriptions = new List<PlanSubscriptionModel>
                    {
                        new PlanSubscriptionModel
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
            });

       
            var plans = new List<BasicPlanModel>
        {
            new BasicPlanModel
            {
                Id = "1",
                ProductName = "Basic Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                     new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {
                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99, Count = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Count", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                }
            },
            new BasicPlanModel
            {
                Id = "2",
                ProductName = "Standard Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                      new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {

                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99, Count = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Count", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                }
            },
            new BasicPlanModel
            {
                Id = "3",
                ProductName = "Premium Plan",
                Active = true,
                SubscriptionFeatures = new List<PlanSubscriptionFeaturesModel>
                {
                     new PlanSubscriptionFeaturesModel { Id = "1",Name="TextToSpeechService",Description="Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, Amount = 9.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "2",Name="Voice Quality",Description="Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, Amount = 29.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "3",Name="Voice Type",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "4",Name="support Types",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                    new PlanSubscriptionFeaturesModel { Id = "5",Name="server Speeds",Description="Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, Amount = 299.99, Active = true },
                },
                TechnicalFeatures = new List<PlanTechnicalFeaturesModel>
                {

                    new PlanTechnicalFeaturesModel { Id = "1", Name = "Number of Requests", Description = "Unlimited requests", Price = 19.99, Count = 10, Status = "Active" },
                    new PlanTechnicalFeaturesModel { Id = "2", Name = "Scope Android", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "3", Name = "Scope Web", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "4", Name = "Scope Report", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                    new PlanTechnicalFeaturesModel { Id = "5", Name = "Scope Word Count", Description = "Unlimited requests", Price = 29.99, Count = 20, Status = "NoActive" },
                }
            }
        };

            basicDB.AddRange(plans);





    }

    public async Task<IEnumerable<PlanModel>?> getAllPlansAsync()
        {
            return db;
        }   
        
        public async Task<IEnumerable<BasicPlanModel>?> getAllBasicPlansAsync()
        {
            return basicDB;
        }


        public async Task<PlanModel?> getPlanByIdAsync(string id)
        {

            return (db.Count > 0) ? db.FirstOrDefault(x => x.Id == id) : null;
        }
    }
}
