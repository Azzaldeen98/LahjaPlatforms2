using Application.Services.Plans;
using Application.UseCase.Plans;
using AutoMapper;
using LAHJA.Data.BlazarComponents.Plans.Category.Model;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Model;
using Domain.Entities.Plans;
using Domain.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LAHJA.Helpers.Services;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model;
using Domain.Entities.Plans.Response;
using System;

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

        public async Task<Result<List<PlanInfo>>> getAllPlansInfoAsync()
        {

            var result = await plansService.getPlansGroupAsync();

            if (result.Succeeded)
            {
                var res = result.Data.ToList();
                var data = _mapper.Map<List<PlanInfoResponse>>(res);
                int i = 0;
                foreach (var item in data)
                {
                    item.TechnicalServices = _mapper.Map<List<PlanTechnicalServiceResponse>>(res[i].SubscriptionFeatures);
                    item.QuantitativeFeatures = _mapper.Map<List<PlanQuantitativeFeatureResponse>>(res[i++].TechnicalFeatures);
                }

                var dataList = _mapper.Map<List<PlanInfo>>(data);
                i = 0;
                foreach (var item in dataList)
                {
                    item.TechnologyServices = _mapper.Map<List<TechnologyService>>(data[i].TechnicalServices);
                    foreach (var itm in item.TechnologyServices)
                        itm.TechnicalServices = new List<TechnicalService>
                        {
                            new TechnicalService { Id = $"TS{new Random().Next(999999)}", Name = "Random Tech", Price = (decimal)(new Random().NextDouble() * 1000), Status = "Active" }
                        };

                    item.ServiceDetailsList = _mapper.Map<List<DigitalService>>(data[i++].QuantitativeFeatures);
                }


                return Result<List<PlanInfo>>.Success(dataList);
            }
            else
            {
                return Result<List<PlanInfo>>.Fail();
            }

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

        public async Task<Result<PlanInfo>> getPlanInfoByIdAsync(string id)
        {
            var item= await plansService.getPlanInfoByIdAsync(id);
            if (item.Succeeded)
            {
                var res= _mapper.Map<PlanInfo>(item);
                return Result<PlanInfo>.Success(res);
            }
            else
            {
                return Result<PlanInfo>.Fail();
            }
            
           

        }
    }
}
