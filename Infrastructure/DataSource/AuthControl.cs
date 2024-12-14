using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Entities.User;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Auth;
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
        private readonly AuthApiClient authApiClient;
        private readonly IMapper _mapper;
        public AuthControl(SeedsUsers seedsUsers, IMapper mapper, AuthApiClient authApiClient)
        {
            this.seedsUsers = seedsUsers;
            _mapper = mapper;
            this.authApiClient = authApiClient;
        }

        public async Task<Result<LoginResponseModel>> loginAsync(LoginRequestModel model)
        {

            //var model= _mapper.Map<LoginRequestModel>(request);
            //var user = await seedsUsers.loginAsync(model);

            var response = await ExecutorAppMode.ExecuteAsync<Result<LoginResponseModel>>(
                async () =>
                {
                   return await authApiClient.loginAsync(model);
                    //if (response == null)
                    //    return Result<LoginResponseModel>.Fail(" ");
                    //else
                    //    return response;
                },
                 async () => {
                      var user=await seedsUsers.loginAsync(model);
                      if (user != null)
                      {
                         var res= _mapper.Map<LoginResponseModel>(user);

                         res.accessToken = authApiClient.GenerateJwtToken("AZDSF!@#$%^&6756345236");

                         return Result<LoginResponseModel>.Success(res);
                      }
                     return Result<LoginResponseModel>.Fail("your email or password is wrong !!");
                 });

            //if (user != null) {

            //   return _mapper.Map<LoginResponseModel>(user);
            //}

            return response;

           
        }

        public async Task<Result<string>> forgetPasswordAsync(string email)
        {

            var response = await ExecutorAppMode.ExecuteAsync<Result<string>>(
                async () =>   await authApiClient.forgetPasswordAsync(email),
                 async () => Result<string>.Success("Success !!"));


            return response;


        }
        public async Task<Result<RegisterResponseModel>> registerAsync(RegisterRequestModel model)
        {

            //var model = _mapper.Map<RegisterRequestModel>(request);
            
            //var res = await seedsUsers.createUserAsync(user);
            var response = await ExecutorAppMode.ExecuteAsync<Result<RegisterResponseModel>>(
               async () =>
               {
                   return await authApiClient.registerAsync(model);
                   //if (response == null)
                   //    return Result<RegisterResponseModel>.Fail(" ");
                   //else
                   //    return response;
               },
                async () => {
                    var user = _mapper.Map<UserApp>(model);
                    if (await seedsUsers.createUserAsync(user))
                    {
                        //var res = _mapper.Map<RegisterResponseModel>(user);
                        return Result<RegisterResponseModel>.Success();
                    }
                    return Result<RegisterResponseModel>.Fail("The email or phoneNumber is not correct !!");
                });

            return response;

            //if (!res)
            //{

            //    return null;
            //}

            //return new RegisterResponseModel();


        }
    }
}
