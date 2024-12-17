using Domain.ShareData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Plans.Response
{
    class SubscriptionPlan : BaseSubscriptionPlan
    {
       public List<BasePlanFeature> Features { get; set; }

    }
}
