namespace Domain.Entities.Auth.Response
{

    public class LoginResponse
    {


        public string? userId { get; set; }
   
        public string? email { get; set; }

        public string? name { get; set; }

        public string? tokenType { get; set; }
        public string? accessToken { get; set; }
        public string? expiresIn { get; set; }
        public string? refreshToken { get; set; }


    }


}
