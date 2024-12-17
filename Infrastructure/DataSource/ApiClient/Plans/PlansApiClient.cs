using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Plans;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Plans
{
    public class PlansApiClient
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PlansApiClient(
            ClientFactory clientFactory, 
            IMapper mapper, 
            IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        private async Task<PlansClient> GetApiClient()
        {

            var client = await _clientFactory.CreateClientWithAuthAsync<PlansClient>("ApiClient");
            return client;
        }


        public async Task<Result<IEnumerable<PlansGroupModel>>> getPlansGroupAsync(int skip=0,int take=0)
        {
            try
            {

                var client = await GetApiClient();
                //var response =  await client.GroupAsync();
                //var resModel = _mapper.Map<IEnumerable<PlansGroupModel>>(response);
                return Result<IEnumerable<PlansGroupModel>>.Success();

            }
            catch (ApiException e)
            {

                return Result<IEnumerable<PlansGroupModel>>.Fail(e.Response);

            }



        }

        //public async Task<Result<IEnumerable<PlansGroupModel>>> getPlansInfoAsync(string id)
        //{
        //    try
        //    {

        //        var client = await GetApiClient();
        //        //var response =  await client.GroupAsync();
        //        //var resModel = _mapper.Map<IEnumerable<PlansGroupModel>>(response);
        //        return Result<IEnumerable<PlansGroupModel>>.Success();

        //    }
        //    catch (ApiException e)
        //    {

        //        return Result<IEnumerable<PlansGroupModel>>.Fail(e.Response);

        //    }



        //}
        public async Task<Result<PlanResponseModel>> getPlanByIdAsync(string id)
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.PlansGetAsync(id);
                var resModel = _mapper.Map<PlanResponseModel>(response);
                return Result<PlanResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<PlanResponseModel>.Fail(e.Response);

            }



        }
    }
}
