using Domain.Entities.User;
using Microsoft.JSInterop;
using Shared.Constants;
using Shared.Helpers;
using System.Threading.Tasks;
namespace LAHJA.Helpers.Services
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
        public async Task SaveRefreshTokenAsync(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.REFRESH_TOKEN, token);
        }
        public async Task SaveExpiresInTokenAsync(string expiresIn)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.EXPIRES_IN_TOKEN, expiresIn);
        }
        public async Task SaveTokenTypeAsync(string tokenType)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.TOKEN_TYPE, tokenType);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.ACCESS_TOKEN) ?? "";
        }
        public async Task<string> GetRefreshTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.REFRESH_TOKEN);
        }
        public async Task<string> GetExpiresInTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.EXPIRES_IN_TOKEN);
        }
        public async Task<string> GetTokenTypeAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.TOKEN_TYPE);
        }

        public async Task SaveAllTokensAsync(string accessToken, string refreshToken,
            string expiresInToken, string tokenType)
        {
            await SaveTokenAsync(accessToken);
            await SaveRefreshTokenAsync(refreshToken);
            await SaveExpiresInTokenAsync(expiresInToken);
            await SaveTokenTypeAsync(tokenType);
        }

        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
        }
        public async Task RemoveAllTokensAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.REFRESH_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.EXPIRES_IN_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.TOKEN_TYPE);
            }
            catch (Exception ex)
            {

            }
        }





    }
}
