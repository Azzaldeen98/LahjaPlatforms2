


using Infrastructure.Models.Plans;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Nswag;
using AutoMapper;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.DataSource.ApiClient.Auth
{



    public class AuthApiClient
    {


        private readonly ClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        public  AuthClient GetApiClientAsync()
        {

            var client =  _clientFactory.CreateClientAsync<AuthClient>("ApiClient");
            return client;
        }


        public async Task<LoginResponseModel?> loginAsync(LoginRequestModel request)
        {
            var model = new LoginRequest
            {
                Email = request.email,
                Password = request.password
            };
            var response =await GetApiClientAsync().LoginAsync(true, true, model);
            var resModel=_mapper.Map<LoginResponseModel>(response);
            return resModel;
            //var token = response.AccessToken;


        }

        public string EncryptToken(string serverToken)
        {
            // Step 1: Create claims including the server token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim("ServerToken", serverToken) // Adding the server token as a claim
            };

            // Step 2: Create the signing key and credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Step 3: Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            // Step 4: Write and return the signed JWT token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<ResponseModel<OutputLogin>> Login(LoginRequest loginRequest)
        //{
        //    try
        //    {
        //        Nswag.LoginRequest loginRequestd = new Nswag.LoginRequest()
        //        {
        //            Email = "afgffgfgfgf@gmail.com",
        //            Password = "Azdeen2025$$$",
        //            TwoFactorCode = "string",
        //            TwoFactorRecoveryCode = "string",
        //            PlanId = "string"
        //        };


        //        _logger.Logg("RepostryAuth Insert login", "info");

        //        var request = new OutputLogin()
        //        {
        //            Token = "ddddd",
        //            ReturnUrl = "/"
        //        };
        //        var ob = await GetApiClientAsync();
        //        if (ob != null)
        //        {
        //            var reuslt = await ob.LoginAsync(false, false, loginRequestd);
        //        }


        //        return ResponseModel<OutputLogin>.SuccessResponse("OutputLogin", request);


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Logg("Error RepostryAuth Login" + ex.Message, "error");
        //        throw new NotImplementedException(ex.Message);
        //    }


        //}

        //public async Task<ResponseModel<OutputLogout>> Logout(string Token)
        //{
        //    try
        //    {
        //        _logger.Logg("RepostryAuth Insert login", "info");
        //        var request = new OutputLogout()
        //        {

        //            ReturnUrl = ""
        //        };

        //        return ResponseModel<OutputLogout>.SuccessResponse("OutputLogin", request);


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Logg("Error RepostryAuth Login" + ex.Message, "error");
        //        throw new NotImplementedException(ex.Message);
        //    }
        //}

        //public async Task<ResponseModel<OutputRigister>> Rigister(VitsModel.Auth.RegisterRequest registerRequest)
        //{
        //    try
        //    {
        //        _logger.Logg("RepostryAuth Insert OutputRigister", "info");
        //        var request = new OutputRigister()
        //        {

        //            ReturnUrl = ""
        //        };


        //        return ResponseModel<OutputRigister>.SuccessResponse("Rigister", request);


        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Logg("Error RepostryAuth OutputRigister" + ex.Message, "error");
        //        throw new NotImplementedException(ex.Message);
        //    }
        //}


    }
}
