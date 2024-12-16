﻿namespace Shared.Helpers
{
    public interface ITokenService
    {
        Task<string?> GetTokenAsync();
        Task<string> GetTokenTypeAsync();
        Task<string> GetExpiresInTokenAsync();

        ///////////////////////////////////////
        Task SaveTokenAsync(string token);
        Task SaveAllTokensAsync(string accessToken, string refreshToken, string expiresInToken, string tokenType);
        Task SaveTokenTypeAsync(string tokenType);
        Task SaveExpiresInTokenAsync(string expiresIn);
        Task SaveRefreshTokenAsync(string token);

        ///////////////////////////////////////
        Task RemoveTokenAsync();
        Task RemoveAllTokensAsync();
    }

}