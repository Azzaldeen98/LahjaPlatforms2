using Application.Services.Plans;
using Application.UseCase.Plans;
using AutoMapper;
using BlazorASG.Data.BlazarComponents.Plans.Category.Model;
using BlazorASG.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using CardShopping.Web.Token;
using Domain.Entities.Plans;
using Domain.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorASG.ClientServices.Plans
{
    public class ClientPlansService
    {
        private readonly PlansService plansService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;



        public ClientPlansService(PlansService plansService, IMapper mapper, TokenService tokenService)
        {

            this.plansService = plansService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<Result<List<PlansFeture>>> getAllBasicPlansAsync()
        {

            var result = await plansService.getAllBasicPlansAsync();

            if ( result.Succeeded)
            {
                var res = result.Data.ToList();
                var data = _mapper.Map<List<PlansFeture>>(res);
                int i = 0;
                foreach (var item in data)
                {
                    item.Services = _mapper.Map<List<Service>>(res[i].SubscriptionFeatures);
                    item.numberOfServices = _mapper.Map<List<NumberOfService>>(res[i++].TechnicalFeatures);
                }
                return Result<List<PlansFeture>>.Success(data);
            }
            else
            {
                return Result<List<PlansFeture>>.Fail();
            }

        }
        public async Task<Result<List<InputCategory>>> getAllPlansContainersAsync()
        {
            var result= await plansService.getAllPlansContainersAsync();
      
            if (result != null && result.Succeeded && result.Data!=null)
            {
                var data = _mapper.Map<List<InputCategory>>(result.Data.ToList());
                return Result<List<InputCategory>>.Success(data);
            }
            else
            {
                return Result<List<InputCategory>>.Fail();
            }

        }

        //public async Task<Result<Plan>> getPlanByIdAsync(string id)
        //{
        //    return await getPlanByIdUseCase.ExecuteAsync(id);

        //}
    }
}
