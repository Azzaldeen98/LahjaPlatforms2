
using AutoMapper;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Repository.Auth;
using Domain.Wrapper;
using Infrastructure.DataSource;
using Shared.Settings;

namespace Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthControl authControl;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public AuthRepository(
            IMapper mapper,
            ApplicationModeService appModeService,
            AuthControl authControl)
        {

            _mapper = mapper;
            this.appModeService = appModeService;
            this.authControl = authControl;
        }



        public async Task<Result<LoginResponse>> loginAsync(LoginRequest model)
        {
      

            var response=await authControl.loginAsync(model);

           if(response == null) {
         
                return Result<LoginResponse>.Fail(" ");
            }
            else
            {
                var res = _mapper.Map<LoginResponse>(response);
              
                return Result<LoginResponse>.Success(res);          
            }
               
            
        }
             public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest model)
            {
      

                    var response=await authControl.registerAsync(model);

                   if(response == null) {
                        //return null;
                        return Result<RegisterResponse>.Fail("فشل التسجيل");
                    }
                    else
                    {
                        var res = _mapper.Map<RegisterResponse>(response);
                        //return res;
                        return Result<RegisterResponse>.Success(res);          
                    }
               
            
              }




    }
}
