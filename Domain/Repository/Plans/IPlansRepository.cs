using Domain.Entities.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Plans
{
    public interface IPlansRepository
    {
        public  Task<IEnumerable<Plan>> getAllPlansAsync();
        public  Task<Plan> getPlanByIdAsync(string id);
    }
}
