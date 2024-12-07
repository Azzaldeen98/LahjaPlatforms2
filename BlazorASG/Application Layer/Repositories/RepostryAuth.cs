using Application.Common.Model;
using Azure.Core;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.Nswag;
using BlazorASG.VitsModel.Auth;
using LoginRequest = BlazorASG.VitsModel.Auth.LoginRequest;

namespace BlazorASG.Application_Layer.Repositories
{
    public class RepostryAuth :IRAuth
    {
        private readonly ILoggerService _logger;

        private readonly BlazorASG.Nswag.ClientFactory _clientFactory;
       
        public RepostryAuth(ILoggerService logger, BlazorASG.Nswag.ClientFactory clientFactory)
        {
            /* _logger = logger*/
            
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<ResponseModel<OutputLogin>> Login(LoginRequest loginRequest)
        {
            try
            {
                Nswag.LoginRequest loginRequestd = new Nswag.LoginRequest()
                {
                    Email = "afgffgfgfgf@gmail.com",
                    Password = "Azdeen2025$$$",
                    TwoFactorCode = "string",
                    TwoFactorRecoveryCode = "string",
                    PlanId = "string"
                };
         
               
                    _logger.Logg("RepostryAuth Insert login", "info");

                var request = new OutputLogin()
                {
                    Token = "ddddd", ReturnUrl = "/"
                };
                var ob =await  GetApiClientAsync();
                if (ob != null)
                { 
                    var reuslt=await ob.LoginAsync(false, false, loginRequestd);
                }

                
                return ResponseModel<OutputLogin>.SuccessResponse("OutputLogin", request);
                 
                 
            }
            catch(Exception ex)
            {
                _logger.Logg("Error RepostryAuth Login"+ ex.Message,"error");
                 throw new NotImplementedException(ex.Message);
            }
           

        }
        public async Task<AuthClient> GetApiClientAsync()
        {
            
            var client = await _clientFactory.CreateClientAsync<AuthClient>("http://asg.tryasp.net/", "ApiClient");
            return client;
        }
        public async Task<ResponseModel<OutputLogout>>Logout(string Token)
        {
            try
            {
                _logger.Logg("RepostryAuth Insert login", "info");
                var request = new OutputLogout()
                {
                   
                    ReturnUrl = ""
                };

                return ResponseModel<OutputLogout>.SuccessResponse("OutputLogin", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("Error RepostryAuth Login"+ex.Message,"error");
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<ResponseModel<OutputRigister>> Rigister(VitsModel.Auth.RegisterRequest registerRequest)
        {
            try
            {
                _logger.Logg("RepostryAuth Insert OutputRigister", "info");
                var request = new OutputRigister()
                {
                     
                    ReturnUrl = ""
                };


                return ResponseModel<OutputRigister>.SuccessResponse("Rigister", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("Error RepostryAuth OutputRigister"+ex.Message,"error");
                throw new NotImplementedException(ex.Message);
            }
        }

        
    }
}
