namespace Shared.Helpers
{
    public interface ITokenService
    {
        Task<string?> GetTokenAsync();
        Task SaveTokenAsync(string token);
        Task RemoveTokenAsync();
    }

}