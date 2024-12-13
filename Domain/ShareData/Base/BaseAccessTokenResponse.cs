namespace Domain.ShareData.Base
{
    public class BaseAccessTokenResponse
    {
        public string? tokenType { get; set; }
        public string? accessToken { get; set; }
        public string? expiresIn { get; set; }
        public string? refreshToken { get; set; }
    }
}
