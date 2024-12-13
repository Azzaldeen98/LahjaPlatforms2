
using AutoMapper;
using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class PlansRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly SeedsPlansContainers seedsPlansContainers;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PlansRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            SeedsPlansContainers seedsPlansContainers)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;
            this.seedsPlansContainers = seedsPlansContainers;
        }

        public async Task<IEnumerable<Plan>?> getAllPlansAsync()
        {


            var response = await ExecutorAppMode.ExecuteAsync<IEnumerable<PlanModel>>(
                 async () => new List<PlanModel>(),
                 () => seedsPlans.getAllPlansAsync()

             );

            var result = (response != null) ? _mapper.Map<IEnumerable<Plan>>(response):null;
            return result;


        }

        public async Task<IEnumerable<PlansContainer>> getAllPlansContainerAsync()
        {

            var response = await ExecutorAppMode.ExecuteAsync<IEnumerable<PlansContainerModel>>(
                 async () => new List<PlansContainerModel>(),
                  () =>  seedsPlansContainers.getAllAsync());

            var result = (response != null) ? _mapper.Map<IEnumerable<PlansContainer>>(response) : null;
            return result;
        }

        public async Task<IEnumerable<BasicPlan>> getAllBasicPlansAsync()
        {

            var response = await ExecutorAppMode.ExecuteAsync<IEnumerable<BasicPlanModel>>(
                 async () => new List<BasicPlanModel>(),
                  () => seedsPlans.getAllBasicPlansAsync());

            var result = (response != null) ? _mapper.Map<IEnumerable<BasicPlan>>(response) : null;
            return result;
        }

        public async Task<Plan> getPlanByIdAsync(string id)
        {

            var res = await seedsPlans.getPlanByIdAsync(id);
            var result = _mapper.Map<Plan>(res);
            return result;


        }


    } 
}
