using AutoMapper;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.Data.BlazarComponents.Plans.Category.DataModel;
using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model;
using LAHJA.Data.UI.Components.Authentication;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using LAHJA.UI.Components.PlanCard.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace LAHJA.Data.UI.Templates.Plans
{
    //public class TemplatePlans: TemplateBase
    //{
    //    //[Inject] public PlansClientService PlansClientService { get; set; }

    //    private readonly PlansClientService _plansClientService;
        


    //    public TemplatePlans(PlansClientService plansClientService,
    //                        IMapper mapper,
    //                        NavigationManager navigation,
    //                        AuthService authService,
    //                        IDialogService dialogService,
    //                        ISnackbar snackbar
    //        )
    //    : base(mapper, navigation, authService,dialogService,snackbar)
    //    {

    //        _plansClientService = plansClientService;
    //        OnInitializedAsync = getAllPlansContainersAsync;
    //        OnSubmitContainerPlanAsync = getSubscriptionsPlansAsync;
    //    }



    //    public Func<Task> OnInitializedAsync { get; set; }
    //    public Func<InputCategory, Task> OnSubmitContainerPlanAsync { get; set; }

    //    public List<string> Errors { get => _errors; }
    //    public List<InputCategory> ContainersPlans { get => _containersPlans; }
    //    public List<PlanInfo> SubscriptionsPlans { get => _subscriptionsPlans; }



    //    private List<InputCategory> _containersPlans = new List<InputCategory>();

    //    private List<PlanInfo> _subscriptionsPlans=new List<PlanInfo>();


    //    private async Task getAllPlansContainersAsync()
    //    {
  
    //        try
    //        {

    //            var result = await _plansClientService.getAllPlansContainersAsync();

    //            if (result.Succeeded && result.Data != null)
    //            {
    //                _containersPlans = result.Data;
               
    //            }
    //            else
    //            {
    //                _errors?.Clear();
    //                _errors?.AddRange(result.Messages);
    //            }


    //        }
    //        catch (Exception e)
    //        {

    //        }
        
    //}

    //    private async Task getSubscriptionsPlansAsync(InputCategory container)
    //    {

    //        try
    //        {

    //            var result = await _plansClientService.getAllPlansInfoAsync();

    //            if (result.Succeeded && result.Data != null)
    //            {
    //                _subscriptionsPlans = result.Data;
    //                await ShowPlansInfo(_subscriptionsPlans, container);
    //            }
    //            else
    //            {
    //                _errors?.Clear();
    //                _errors?.AddRange(result.Messages);
    //            }


    //        }
    //        catch (Exception e)
    //        {
    //            Snackbar.Add(e.Message, Severity.Error);
    //        }

    //    }

    //    //private async Task ShowPlansInfo(Data.BlazarComponents.Plans.Category.Model.InputCategory inputCategory)
    //    private async Task ShowPlansInfo(List<PlanInfo> data, InputCategory container)
    //    {
    //        try { 
            

    //                AuthComponent authComponent = new AuthComponent()
    //                {
    //                    IsAuth = await authService.isAuth(),
    //                    PageRouterName = "/login"
    //                };
       
    //              var parameters = new DialogParameters<ListInfoPlans>{
    //              {x => x.TypeTransition,true},
    //              {x => x.IdCategry,container.Id},
    //              {x => x.auth,authComponent},
    //              {x =>x.Params,data} //dataFeaturee.plansList1}
    //          };

    //                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraLarge, FullWidth = true };
    //                //   var dialog = await DialogService.ShowAsync<ListFeatureService>("",parameters, options);
    //                var dialog = await dialogService.ShowAsync<ListInfoPlans>("", parameters, options);
    //                var result = await dialog.Result;
    //                if (!result.Canceled)
    //                {
    //                    var pbj = (PlanInfo)result.Data;
    //                    string url = "/Payment/" + pbj.Id;
    //                    navigation.NavigateTo(url);
    //                }
           


    //        }
    //        catch (Exception ex)
    //        {
    //            Snackbar.Add(ex.Message, Severity.Error);
    //        }


    //    }

    //}
}
