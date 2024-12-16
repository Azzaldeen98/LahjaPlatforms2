using MudBlazor;

namespace LAHJA.Data.BlazarComponents.Shared
{
    public class PageTransition
    {

        public string ReturnPage { get; set;}
        public PageTransitionTypes TransitionTypes { get; set;}
    }
    public enum PageTransitionTypes
    {


         Url= 0,
         Dialog = 1,
         ReturnToEvent= 2,
       


    }
}
