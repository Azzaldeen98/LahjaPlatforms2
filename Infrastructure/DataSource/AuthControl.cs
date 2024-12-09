using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.User;
using Infrastructure.DataSource.Seeds;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource
{
    public class AuthControl
    {
        private readonly SeedsUsers seedsUsers;
        private readonly IMapper _mapper;
        public AuthControl(SeedsUsers seedsUsers, IMapper mapper)
        {
            this.seedsUsers = seedsUsers;
            _mapper = mapper;
        }
 
        public async Task<LoginResponseModel?> loginAsync(LoginRequest request)
        {

            var model= _mapper.Map<LoginRequestModel>(request);
            var user = await seedsUsers.loginAsync(model);

            if (user != null) {

               return _mapper.Map<LoginResponseModel>(user);
            }

            return null;

           
        }
        public async Task<RegisterResponseModel?> registerAsync(RegisterRequest request)
        {

            var model = _mapper.Map<RegisterRequestModel>(request);
            var user = _mapper.Map<UserApp>(model);
            var res = await seedsUsers.createUserAsync(user);

            if (!res)
            {

                return null;
            }

            return new RegisterResponseModel();


        }
    }
}
