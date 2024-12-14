using Domain.Entities.User;
using Microsoft.JSInterop;
using Shared.Constants;
using Shared.Helpers;
using System.Threading.Tasks;
namespace CardShopping.Web.Token
{
    public class TokenService : ITokenService
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveTokenAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.ACCESS_TOKEN, token);
        }
       
        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.ACCESS_TOKEN) ??"";
        }

        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
        }

    }
}
