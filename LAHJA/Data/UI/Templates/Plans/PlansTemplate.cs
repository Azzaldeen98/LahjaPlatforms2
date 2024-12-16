using LAHJA.ApplicationLayer.Plans;
using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Templates.Plans
{
    public class PlansTemplate
    {
        //[Inject] 
        
        private readonly PlansClientService plansClientService;

        public PlansTemplate(PlansClientService plansClientService)
        {
            this.plansClientService = plansClientService;
        }

    }
}
