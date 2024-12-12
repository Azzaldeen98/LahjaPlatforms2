using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Plans
{
    public class PlanModel : BasePlan
    {
        public string? Id { get; set; }
 
        public ICollection<SubscriptionModel>? Subscriptions { get; set; }


    }


}
