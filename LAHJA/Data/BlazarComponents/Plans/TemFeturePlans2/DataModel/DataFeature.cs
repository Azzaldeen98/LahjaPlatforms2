using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
 
namespace LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.DataModel
{
    public class DataFeature
    {
        public List<PlansFeture> plansList = Enumerable.Range(1, 10).Select(i => new PlansFeture
        {
            Id = Guid.NewGuid().ToString(),
            
           
            Name = $"Plan {i}",
            Description = $"Description for Plan {i}",
            Status = i % 2 == 0 ? "Active" : "Inactive",
            Price = i * 50m,
            Services = Enumerable.Range(1, 3).Select(j => new Service
            {
                Name = $"Service {j} for Plan {i}",
                Price = j * 10m,
                Description = $"Description for Service {j} in Plan {i}",
                Status = j % 2 == 0 ? "Available" : "Unavailable"
            }).ToList(),
            numberOfServices = Enumerable.Range(1, 2).Select(k => new NumberOfService
            {
                Count = k * 5,
                Price = k * 20m,
                Description = $"Package {k} in Plan {i}",
                Status = k % 2 == 0 ? "Available" : "Unavailable"
            }).ToList()
        }).ToList();



        public List<PlansFeture> plansList1 = new List<PlansFeture>()
        {

            new PlansFeture()
            {

             Id = Guid.NewGuid().ToString(),
             IdCategory="F002",

            Name = "Basic Plan",
            Description = "Description for Plan",
            Status = "Active",
            Price = 40,
            Services=new List<Service>()
            {
               new ()
               {

                 Id="n1",Name="TextToSpeechService",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Text-to-Speech" 
                   }
               },
                new Service()
               {
                    Id="n2",Name="Voice Quality",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Voice Quality"
                   }
               },
                   new Service()
               {
                    Id="n3",Name="Voice Type",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Male and female voices"
                   }
               },
                      new Service()
               {
                   Id="n4", Name="support Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "customer support"
                   } 
                      },
                      new Service(){
                  Id="n5",Name="server Speeds",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Speed"
                   } 
                      }
                   ,
                          new Service(){
                    Id="n6",Name="security Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Basic Security"
                   }
                      }
                   ,
                                    new Service(){
                  Id="n7",  Name="other Services",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Additional Service 1"
                   }
                      }
                   ,
                       new Service(){
                    Id="n8",Name="message Storage",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Storage"
                   }
               }


            }
            ,
            numberOfServices=new List<NumberOfService>()
            {
                new NumberOfService()
                {
                     Id="i1",Name=" Number of Requests",Description="Unlimited requests",Price=40,Status="Active",Count=60
                },

                 new NumberOfService()
                {
                      Id="i2",Name=" Scope Android",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },

                 new NumberOfService()
                {
                     Id="i3", Name=" Scope Web",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                   new NumberOfService()
                {
                     Id="i4", Name=" Scope Report",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                     new NumberOfService()
                {
                     Id="i4", Name="Word Count ",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
            }

            },
             new PlansFeture()
            {

             Id = Guid.NewGuid().ToString(),
             IdCategory="F002",
            Name = "Basic Plan",
            Description = "Description for Plan",
            Status = "Active",
            Price = 40,
            Services=new List<Service>()
            {
               new ()
               {

                 Id="n1",Name="TextToSpeechService",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Text-to-Speech"
                   }
               },
                new Service()
               {
                    Id="n2",Name="Voice Quality",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Voice Quality"
                   }
               },
                   new Service()
               {
                    Id="n3",Name="Voice Type",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Male and female voices"
                   }
               },
                      new Service()
               {
                   Id="n4", Name="support Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "customer support"
                   }
                      },
                      new Service(){
                  Id="n5",Name="server Speeds",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Speed"
                   }
                      }
                   ,
                          new Service(){
                    Id="n6",Name="security Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Basic Security"
                   }
                      }
                   ,
                                    new Service(){
                  Id="n7",  Name="other Services",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Additional Service 1"
                   }
                      }
                   ,
                       new Service(){
                    Id="n8",Name="message Storage",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Storage"
                   }
               }


            }
            ,
            numberOfServices=new List<NumberOfService>()
            {
                new NumberOfService()
                {
                     Id="i1",Name=" Number of Requests",Description="Unlimited requests",Price=40,Status="Active",Count=60
                },

                 new NumberOfService()
                {
                      Id="i2",Name=" Scope Android",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },

                 new NumberOfService()
                {
                     Id="i3", Name=" Scope Web",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                   new NumberOfService()
                {
                     Id="i4", Name=" Scope Report",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                   new NumberOfService()
                {
                     Id="i4", Name="Word Count ",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
            }

            },
              new PlansFeture()
            {

             Id = Guid.NewGuid().ToString(),
             IdCategory="F002",
             Name = "Basic Plan",
            
            
            Description = "Description for Plan",
            Status = "Active",
            Price = 40,
            Services=new List<Service>()
            {
               new ()
               {

                 Id="n1",Name="TextToSpeechService",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Text-to-Speech"
                   }
               },
                new Service()
               {
                    Id="n2",Name="Voice Quality",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Voice Quality"
                   }
               },
                   new Service()
               {
                    Id="n3",Name="Voice Type",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Male and female voices"
                   }
               },
                      new Service()
               {
                   Id="n4", Name="support Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "customer support"
                   }
                      },
                      new Service(){
                  Id="n5",Name="server Speeds",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Speed"
                   }
                      }
                   ,
                          new Service(){
                    Id="n6",Name="security Types",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Basic Security"
                   }
                      }

                   ,
                    new Service(){
                  Id="n7",  Name="other Services",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "Additional Service 1"
                   }
                      }
                   ,
                       new Service(){
                    Id="n8",Name="message Storage",Description="Basic text-to-speech service",Price=30,Status="Active",listt=new List<string>()
                   {
                       "1 GB Storage"
                   }
               }


            }
            ,
            numberOfServices=new List<NumberOfService>()
            {
                new NumberOfService()
                {
                     Id="i1",Name=" Number of Requests",Description="Unlimited requests",Price=40,Status="Active",Count=60
                },

                 new NumberOfService()
                {
                      Id="i2",Name=" Scope Android",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },

                 new NumberOfService()
                {
                     Id="i3", Name=" Scope Web",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                   new NumberOfService()
                {
                     Id="i4", Name=" Scope Report",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
                     new NumberOfService()
                {
                     Id="i4", Name="Word Count ",Description="Unlimited requests",Price=40,Status="Active",Count=3
                },
            }

            }
        };



        }
        }

          

       
           
            
           
         
         
 

