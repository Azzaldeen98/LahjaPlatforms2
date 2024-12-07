using Application.Common.Model;
using Azure.Core;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.Application_Layer.Repositories;
using BlazorASG.Nswag;
using BlazorASG.VitsModel;
using BlazorASG.VitsModel.Auth;
using CardShopping.Web.Token;
using Newtonsoft.Json.Linq;
using LoginRequest = BlazorASG.VitsModel.Auth.LoginRequest;

namespace BlazorASG.Application_Layer.Use_Cases.Auth
{
    public class CreateLogin
    {

        private readonly IRAuth _irauth;
        private readonly ILoggerService _logger;
        private readonly TokenService _tokenService;


        public CreateLogin(IRAuth rAuth, ILoggerService consoleLogger, TokenService tokenService)
        {
            _irauth = rAuth;
            _logger = consoleLogger;
            _tokenService = tokenService;
        }

        public async Task<ResponseModel<OutputLogin>> Createdep(LoginRequest loginRequest)
        {
            try
            {
                var tokenn = await _tokenService.GetTokenAsync();
                if (!string.IsNullOrEmpty(tokenn))
                {


                    string[] x = tokenn.Split(',');
                    if (loginRequest.Email == x[0])
                    {
                        var request = new OutputLogin()
                        {
                            Token = "ddddd",
                            ReturnUrl = "/"
                        };

                        if( loginRequest.Password == x[1])
                        {
                            return ResponseModel<OutputLogin>.SuccessResponse("CreateDep", request);
                        }
                       
                        else
                        {
                            return ResponseModel<OutputLogin>.FailureResponse("Erorr Password");
                        }
                     
                    }
                    else
                    {
                        return ResponseModel<OutputLogin>.FailureResponse("Erorr Email");
                    }





                }

                return ResponseModel<OutputLogin>.FailureResponse("Not Found");
            }
            catch (Exception ex)
            {
                _logger.Logg("CreateLogin  class" + ex.Message, "error");
                throw new NotImplementedException(ex.Message);
            }
        }
        public async Task<ResponseModel<OutputLogin>> Create(LoginRequest loginRequest)
        {
            try
            {

                _logger.Logg("CreateLogin class", "info");
                return await _irauth.Login(loginRequest);


                // return ResponseModel<OutputLogin>.SuccessResponse("OutputLogin", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("CreateLogin  class" + ex.Message, "error");
                throw new NotImplementedException(ex.Message);
            }
        }
        public async Task<ResponseModel<OutputRigister>> CreateRegisterDb(VitsModel.Auth.RegisterRequest loginRequest)
        {
            return null;
        }
      
             


    }

}
