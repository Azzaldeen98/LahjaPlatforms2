
using AutoMapper;
using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Shared.Settings;

namespace Infrastructure.Repository.Plans
{
    public class PlansRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PlansRepository(IMapper mapper, ApplicationModeService appModeService)
        {

            seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.appModeService = appModeService;
        }

        public async Task<IEnumerable<Plan>> getAllPlansAsync()
        {


            var response = await ExecutorAppMode.ExecuteAsync<IEnumerable<PlanModel>>(
                 async () => new List<PlanModel>(),
                 () => seedsPlans.getAllPlansAsync()

             );

            var result = _mapper.Map<IEnumerable<Plan>>(response);
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
