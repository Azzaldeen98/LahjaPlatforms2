


using Infrastructure.Models.Plans;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Nswag;
using AutoMapper;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Domain.Wrapper;


//using Microsoft.AspNetCore.Http;

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

        public  async Task<AuthClient> GetApiClient()
        {

            var client = await _clientFactory.CreateClientAsync<AuthClient>("ApiClient");
            return client;
        }


        public async Task<Result<string>> forgetPasswordAsync(string email)
        {
            return Result<string>.Success(email);
        }
        public async Task<Result<LoginResponseModel>> loginAsync(LoginRequestModel request)
        {
            try
            {
                var model = _mapper.Map<LoginRequest>(request);
                //var model = new LoginRequest
                //{
                //    Email = request.email,
                //    Password = request.password
                //};
                var client = await GetApiClient();
                var response =await client.LoginAsync(true, true, model);
                var resModel = _mapper.Map<LoginResponseModel>(response);
                return Result<LoginResponseModel>.Success(resModel);
                //return resModel;

            }catch(ApiException e)
            {

                return Result<LoginResponseModel>.Fail(e.Response);
               
            }
            //var token = response.AccessToken;


        }


        public async Task<Result<RegisterResponseModel>> registerAsync(RegisterRequestModel request)
        {
            try
            {
                var model = _mapper.Map<RegisterRequest>(request);
             
                //var model = new LoginRequest
                //{
                //    Email = request.email,
                //    Password = request.password
                //};
                var client = await GetApiClient();
               await client.RegisterAsync(model);

                //var resModel = _mapper.Map<RegisterResponseModel>(response);

                return Result<RegisterResponseModel>.Success();
                //return resModel;

            }
            catch (ApiException e)
            {

                return Result<RegisterResponseModel>.Fail(e.Response);

            }
            //var token = response.AccessToken;


        }
        public string GenerateJwtToken(string serverToken, string role="")
        {
            var claims = new[]
            {
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,"LahagaWebSiteAccessToken"),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim("ServerToken", serverToken),
            //new Claim(ClaimTypes.Role, role)
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LahagaWebSiteApp63727&^%$@#@8gdsdgsug"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                     issuer: "LahagaWebSiteApp",
                audience: "LahagaWebSiteAPIClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        public async Task SaveLoginUser(string token,string role = "User") {


            var claims = new List<Claim>
                            {
                                new Claim("accessToken" ,  token),
                                new Claim("accessTokenHash" ,  ""),
                                new Claim("RefreshToken" ,  ""),
                                new Claim("email",""),
                                new Claim("id",""),
                                new Claim("role",role),

                            };
            var userIdentity = new ClaimsIdentity(claims, "Bearer");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            // قم بتسجيل المستخدم في الجلسة
            //await Microsoft.AspNetCore.Http.HttpContext.  SignInAsync(principal);
        }
        public string EncryptToken(string serverToken,string role="User")
        {
            // Step 1: Create claims including the server token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]??""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim("ServerToken", serverToken), // Adding the server token as a claim
                new Claim(ClaimTypes.Role, role)

                //new Claim(JwtClaimTypes.Id, user.Id),
                //new Claim(JwtClaimTypes.Email, user?.Email??""),
                //new Claim(JwtClaimTypes.Role,(await _userManager.GetRolesAsync(user)).FirstOrDefault()??""),
            };

            // Step 2: Create the signing key and credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));
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
