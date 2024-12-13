using Domain.Entities.User;
using Microsoft.JSInterop;
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
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "accessToken", token);
        }
       
        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "accessToken")??"";
        }

        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", "accessToken");
        }

    }
}
