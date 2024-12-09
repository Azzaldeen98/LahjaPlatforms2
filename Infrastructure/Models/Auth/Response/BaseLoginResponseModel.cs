namespace Infrastructure.Models.Plans
{
    public class BaseLoginResponseModel
    {
        public string? tokenType { get; set; }
        public string? accessToken { get; set; }
        public string? expiresIn { get; set; }
        public string? refreshToken { get; set; }
    }


}
