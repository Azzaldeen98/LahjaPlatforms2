namespace Infrastructure.Models.User
{
    public class UserResponseModel
    {

        public string? customerId { get; set; }
        public string? email { get; set; }
        public bool isEmailConfirmed { get; set; }

    }
}
