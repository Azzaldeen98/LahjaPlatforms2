using Blazorise.Extensions;
using CardShopping.Web.Token;
using Microsoft.JSInterop;

namespace BlazorASG.Token
{
    public class AuthCheckedService
    {
        private readonly TokenService tokenService;
        public AuthCheckedService(TokenService tokenService)
        {
       
            this.tokenService = tokenService;
        }

        public async Task<bool> isAuth()
        {
            var token = await tokenService.GetTokenAsync();
            return  !token.IsNullOrEmpty();
        }
    }
}
