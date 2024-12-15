using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Profile
{
    public class ProfileApiClient: BaseApiClient
    {

        public ProfileApiClient(ClientFactory clientFactory,IMapper mapper,IConfiguration config)
            :base(clientFactory, mapper, config) { 
        }

        public async Task<object> getApiClient()
        {
            
            //var client = await _clientFactory.CreateClientWithAuthAsync<ProfileClient>("ApiClient");
            return null;
        }
        public async Task<Result<ProfileResponseModel>> getProfileAsync()
        {
            try
            {

                var client = await getApiClient();
                //var response = await client.PlansGetAsync(id);
                //var resModel = _mapper.Map<ProfileResponseModel>(response);
                return Result<ProfileResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<ProfileResponseModel>.Fail(e.Response);

            }



        }
    }
}
