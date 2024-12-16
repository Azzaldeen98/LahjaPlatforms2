using Application.Services.Plans;
using Application.UseCase.Plans;
using AutoMapper;
using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using Domain.Entities.Plans;
using Domain.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LAHJA.Helpers.Services;

namespace LAHJA.ApplicationLayer.Plans
{
    public class PlansClientService
    {
        private readonly PlansService plansService;
        private readonly TokenService tokenService;
        private readonly IMapper _mapper;



        public PlansClientService(PlansService plansService, IMapper mapper, TokenService tokenService)
        {

            this.plansService = plansService;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<Result<List<PlansFeture>>> getPlansGroupAsync()
        {

            var result = await plansService.getPlansGroupAsync();

            if (result.Succeeded)
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
            var result = await plansService.getAllPlansContainersAsync();

            if (result != null && result.Succeeded && result.Data != null)
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
