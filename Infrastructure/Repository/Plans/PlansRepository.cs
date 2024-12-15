﻿
using AutoMapper;
using Domain.Entities.Plans.Response;
using Domain.Repository.Plans;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class BaseRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PlansApiClient plansApiClient;
        private readonly SeedsPlansContainers seedsPlansContainers;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public BaseRepository(
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
       
        public async Task<Result<IEnumerable<PlansContainerResponse>>> getAllPlansContainerAsync()
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<IEnumerable<PlansContainerModel>>>(
                 async () => Result<IEnumerable<PlansContainerModel>>.Success(),
                 async () => Result<IEnumerable<PlansContainerModel>>.Success(await seedsPlansContainers.getAllAsync()));



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

        public async Task<Result<PlanResponse>> getPlanByIdAsync(string id)
        {
                var response = await ExecutorAppMode.ExecuteAsync<Result<PlanResponseModel>>(
                 async () => await plansApiClient.getPlanByIdAsync(id),
                 async () => Result<PlanResponseModel>.Success(await seedsPlans.getPlanByIdAsync(id))
);
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
       
    } 
}
