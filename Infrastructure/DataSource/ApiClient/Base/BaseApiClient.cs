using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Base
{
    public class BaseApiClient
    {

        protected readonly ClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;
        public BaseApiClient(
            ClientFactory clientFactory,
            IMapper mapper,
            IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

    }
}
