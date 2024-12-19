
using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Shared.Settings;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Infrastructure.Repository.Plans
{
    public class PlansRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PlansApiClient plansApiClient;
        private readonly SeedsPlansContainers seedsPlansContainers;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PlansRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            SeedsPlansContainers seedsPlansContainers,
            PlansApiClient plansApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;
            this.seedsPlansContainers = seedsPlansContainers;
            this.plansApiClient = plansApiClient;
        }

        public async Task<Result<IEnumerable<PlanResponse>>> getAllPlansAsync()
        {
        

            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlanResponseModel>>>(
                 async () => Result<IEnumerable<PlanResponseModel>>.Success(),
                 async () => Result<IEnumerable<PlanResponseModel>>.Success(await seedsPlans.getAllPlansAsync())

             );
            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlanResponse>>(response.Data) : null;
                return Result<IEnumerable<PlanResponse>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<PlanResponse>>.Fail(response.Messages);
            }
          

        }

        public async Task<Result<IEnumerable<ContainerPlans>>> getAllContainersPlansAsync()
        {


            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<ContainerPlansModel>>>(
            async () => await plansApiClient.getAllContainersPlansAsync(),
            async () => Result<IEnumerable<ContainerPlansModel>>.Success(await seedsPlansContainers.getAllAsync()));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<ContainerPlans>>(response.Data) : null;
                return Result<IEnumerable<ContainerPlans>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<ContainerPlans>>.Fail(response.Messages);
            }
        }


        public async Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync()
        {

       


            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansContainerModel>>>(
            async () => Result<IEnumerable<PlansContainerModel>>.Success(),
            async () => Result<IEnumerable<PlansContainerModel>>.Success(await seedsPlansContainers.getAllContainersAsync()));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansContainerResponse>>(response.Data) : null;
                return Result<IEnumerable<PlansContainerResponse>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<PlansContainerResponse>>.Fail(response.Messages);
            }
        }

        public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansGroupAsync()
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansGroupModel>>>(
                 async () => await plansApiClient.getPlansGroupAsync(),
                  async () => Result<IEnumerable<PlansGroupModel>>.Success(await seedsPlans.getPlansGroupAsync()
                  ));

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansGroupResponse>>(response.Data) : null;
                return Result<IEnumerable<PlansGroupResponse>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<PlansGroupResponse>>.Fail(response.Messages);
            }


        
        }
        public async Task<Result<IEnumerable<PlansGroupResponse>>> getPlansByGroupIdAsync(string id)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansGroupModel>>>(
                 async () => await plansApiClient.getPlansGroupAsync(),
                  async () => Result<IEnumerable<PlansGroupModel>>.Success(await seedsPlans.getPlansGroupAsync()
                  ));

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlansGroupResponse>>(response.Data) : null;
                return Result<IEnumerable<PlansGroupResponse>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<PlansGroupResponse>>.Fail(response.Messages);
            }



        }
        public async Task<Result<PlanResponse>> getPlanByIdAsync(string id)
        {
                var response = await ExecutorAppMode.ExecuteAsync<Result<PlanResponseModel>>(
                 async () => await plansApiClient.getPlanByIdAsync(id),
                 async () => Result<PlanResponseModel>.Success(await seedsPlans.getPlanByIdAsync(id)));
                if (response.Succeeded)
                {
                    var result = (response.Data != null) ? _mapper.Map<PlanResponse>(response.Data) : null;
                    return Result<PlanResponse>.Success(result);
                }
                else
                {
                    return Result<PlanResponse>.Fail(response.Messages);
                }
        }

        public async Task<Result<PlanInfoResponse>> GetPlanInfoByIdAsync(string id)
        {

        

                 var response = await ExecutorAppMode.ExecuteAsync<Result<PlanResponseModel>>(
                 async () => Result<PlanResponseModel>.Success(new PlanResponseModel()),
                 async () => Result<PlanResponseModel>.Success(await seedsPlans.getPlanByIdAsync(id)));
                  
                 if (response.Succeeded)
                    {
                        var result = (response.Data != null) ? _mapper.Map<PlanInfoResponse>(response.Data) : null;
                        return Result<PlanInfoResponse>.Success(result);
                    }
                    else
                    {
                        return Result<PlanInfoResponse>.Fail(response.Messages);
                    }

        }

        public async Task<Result<IEnumerable<SubscriptionPlan>>> getSubscriptionsPlansAsync(string containerId)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<SubscriptionPlanModel>>>(
          async () => Result<IEnumerable<SubscriptionPlanModel>>.Success(),
          async () => Result<IEnumerable<SubscriptionPlanModel>>.Success(await seedsPlansContainers.getSubscriptionsPlansAsync(containerId)));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<SubscriptionPlan>>(response.Data) : null;
                return Result<IEnumerable<SubscriptionPlan>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<SubscriptionPlan>>.Fail(response.Messages);
            }
        }
        public async Task<Result<IEnumerable<SubscriptionPlan>>> getAllSubscriptionsPlansAsync(int skip=0,int take=0)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<SubscriptionPlanModel>>>(
            async () => await plansApiClient.getAllSubscriptionsPlansAsync(),
            async () => Result<IEnumerable<SubscriptionPlanModel>>.Success(await seedsPlansContainers.getAllSubscriptionsPlansAsync()));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<SubscriptionPlan>>(response.Data) : null;
                return Result<IEnumerable<SubscriptionPlan>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<SubscriptionPlan>>.Fail(response.Messages);
            }
        }

        public async Task<Result<IEnumerable<PlanFeature>>> getSubscriptionsPlansFeaturesAsync(string planId)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlanFeatureModel>>>(
              async () => Result<IEnumerable<PlanFeatureModel>>.Success(),
              async () => Result<IEnumerable<PlanFeatureModel>>.Success(await seedsPlansContainers.getSubscriptionsPlansFeaturesAsync(planId)));


            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<IEnumerable<PlanFeature>>(response.Data) : null;
                return Result<IEnumerable<PlanFeature>>.Success(result);
            }
            else
            {
                return Result<IEnumerable<PlanFeature>>.Fail(response.Messages);
            }
        }
    } 
}
