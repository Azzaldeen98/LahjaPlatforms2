
using AutoMapper;
using Domain.Entities.Plans;
using Domain.Repository.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Plans
{
    public class PlansRepository : IPlansRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly IMapper _mapper;
        public PlansRepository(IMapper mapper) {

            seedsPlans= new SeedsPlans();
            _mapper = mapper;
        }

      public async  Task<IEnumerable<Plan>> getAllPlansAsync()
      {
        
                var res = await seedsPlans.getAllPlansAsync();
                var result = _mapper.Map<IEnumerable<Plan>>(res);
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
