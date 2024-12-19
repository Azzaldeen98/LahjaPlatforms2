using AutoMapper;
using Blazorise;
using Domain.Entities.Auth.Request;
using Domain.Entities.Plans.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAHJA.Data.UI.Templates.Plans
{

    public class DataBuildPlansBase
    {
        public string CategoryId{ get; set; }
        public string PlanId{ get; set; }
    }


    public interface IBuilderPlansComponent<T> : IBuilderComponents<T>
    {
        //public Func<T, Task> Submit { get; set; }
        public Func<T, Task> SubmitContainerPlans { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }

        //public List<InputCategory> Categories { get; set; }
        //public List<SubscriptionPlan> SubscriptionPlans { get; set; }
        //public List<PlanFeature> PlanFeatures { get; set; }
     
    }



    public interface IBuilderPlansApi<T> : IBuilderApi<T>
    {


         //Task<Result<List<InputCategory>>> OnInitialize();
         Task<Result<List<InputCategory>>> GetAllCategories();
        Task<Result<List<SubscriptionPlan>>> getSubscriptionsPlansAsync(T data);
        Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync();
        Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(T data);

    
        //Task<Result<List<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId);
        //Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0);
        //Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(string planId);

    }

    public abstract class BuilderPlansApi<T, E> : BuilderApi<T, E>, IBuilderPlansApi<E>
    {

        public BuilderPlansApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();
        public abstract Task<Result<List<InputCategory>>> GetAllCategories();

        public abstract Task<Result<List<SubscriptionPlan>>> getSubscriptionsPlansAsync(E data);  
        
        public abstract Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync();
     

        public abstract Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(E data);
      



        //public Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip = 0, int take = 0)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<List<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(string planId)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class BuilderPlansComponent<T> : IBuilderPlansComponent<T>
    {
        //public Func<T, Task> Submit { get; set; }
        public Func<T, Task> SubmitContainerPlans { get; set; }
        public Func<T, Task> SubmitSubscriptionPlan { get; set; }

        //public List<InputCategory> Categories { get; set; }
        //public List<SubscriptionPlan> SubscriptionPlans { get; set; }
        //public List<PlanFeature> PlanFeatures { get; set; }
    }


    public class TemplatePlansShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderPlansApi<E> builderApi;
        private readonly IBuilderPlansComponent<E> builderComponents;
        public IBuilderPlansComponent<E> BuilderComponents { get => builderComponents; }
        public TemplatePlansShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderPlansComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client){



            builderComponents = new BuilderPlansComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }


    public class BuilderPlansApiClient : BuilderPlansApi<PlansClientService, DataBuildPlansBase>, IBuilderPlansApi<DataBuildPlansBase>
    {
        public BuilderPlansApiClient(IMapper mapper, PlansClientService service) : base(mapper, service)
        {
        }

   
        public override async Task<Result<List<InputCategory>>> GetAllCategories()
        {
           
            var res= await Service.getAllContainersAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<InputCategory>>(res.Data);
                    return Result<List<InputCategory>>.Success(map);

                }catch(Exception e)
                {
                    return Result<List<InputCategory>>.Fail();
                }
            }
            else
            {
                return Result<List<InputCategory>>.Fail(res.Messages);
            }
        }

 
        public override async Task<Result<List<SubscriptionPlan>>> getAllSubscriptionsPlansAsync()
        {
           
            var res = await Service.getAllSubscriptionPlansAsync();
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<SubscriptionPlan>>(res.Data);
                return Result<List<SubscriptionPlan>>.Success(map);
            }
            else
            {
                return Result<List<SubscriptionPlan>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<SubscriptionPlan>>> getSubscriptionsPlansAsync(DataBuildPlansBase data)
        {
            //return await Service.getSubscriptionsPlansAsync(data.CategoryId);

            var res = await Service.getSubscriptionsPlansAsync(data.CategoryId);
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<SubscriptionPlan>>(res.Data);
                return Result<List<SubscriptionPlan>>.Success(map);
            }
            else
            {
                return Result<List<SubscriptionPlan>>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<PlanFeature>>> getSubscriptionPlanFeaturesAsync(DataBuildPlansBase data)
        {
            //return await Service.getSubscriptionPlanFeaturesAsync(data.PlanId);


            var res = await Service.getSubscriptionPlanFeaturesAsync(data.PlanId);
            if (res.Succeeded)
            {
                var map = Mapper.Map<List<PlanFeature>>(res.Data);
                return Result<List<PlanFeature>>.Success(map);
            }
            else
            {
                return Result<List<PlanFeature>>.Fail(res.Messages);
            }
        }

    
    }


    public class TemplatePlans : TemplatePlansShare<PlansClientService, DataBuildPlansBase>
    {
        public List<InputCategory> Categories { get=> _categories; }
        public List<SubscriptionPlan> SubscriptionPlans { get; set; }
        public List<PlanFeature> PlanFeatures { get; set; }
        public List<string> Errors { get => _errors; }


        public TemplatePlans(
            IMapper mapper,
            AuthService AuthService,
            PlansClientService client,
            IBuilderPlansComponent<DataBuildPlansBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitContainerPlans = OnSubmitContainerPlans;
            this.BuilderComponents.SubmitSubscriptionPlan = OnSubmitSubscriptionPlan;

            this.builderApi = new BuilderPlansApiClient(mapper, client);

            Task.FromResult(OnInitialize());

        }



 
       


        private List<InputCategory> _categories = new List<InputCategory>();

        //public  IBuilderPlansComponent<DataBuildPlansBase, DataBuildPlansBase> BuilderPlansComponent { get => builderPlansComponents; }



        private async Task OnInitialize()
        {
                var response = await builderApi.GetAllCategories();
                if (response.Succeeded)
                {
                   _categories = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            

        } private async Task OnSubmitContainerPlans(DataBuildPlansBase dataBuildPlansBase)
        {

            if (dataBuildPlansBase != null)
            {
                var response = await builderApi.getSubscriptionsPlansAsync(dataBuildPlansBase);
                if (response.Succeeded)
                {
                    //BuilderComponents.SubscriptionPlans = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }

        private async Task OnSubmitSubscriptionPlan(DataBuildPlansBase dataBuildPlansBase)
        {
            

            if (dataBuildPlansBase != null)
            {
                var response = await builderApi.getSubscriptionPlanFeaturesAsync(dataBuildPlansBase);
                if (response.Succeeded)
                {
                    //BuilderComponents.PlanFeatures = response.Data;
                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }  
       

    }

}
