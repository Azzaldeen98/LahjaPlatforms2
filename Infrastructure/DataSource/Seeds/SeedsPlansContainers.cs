using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlansContainers
    {
      private static List<PlansContainerModel> db= new List<PlansContainerModel>();


        public SeedsPlansContainers()
        {
            
            //List<PlansContainerModel> plansList = ;
            db.AddRange(new List<PlansContainerModel>{
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
        });
            
        } 
    
        public async Task<IEnumerable<PlansContainerModel>?> getAllAsync()
        {
          
            return db;
        }


       
    }
}
