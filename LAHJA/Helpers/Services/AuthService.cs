using Blazorise.Extensions;
using Microsoft.JSInterop;

namespace LAHJA.Helpers.Services
{
    public class AuthService
    {
        private readonly TokenService tokenService;
        public AuthService(TokenService tokenService)
        {

            this.tokenService = tokenService;
        }

        public async Task<bool> isAuth()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> isMyself()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }


    }
}
