namespace Domain.Entities.Auth.Request
{
    public class ConfirmationEmail
    {
        public  string UserId { get; set; }
        public  string Code { get; set; }

        public  string ChangedEmail { get; set; }
    }


}
