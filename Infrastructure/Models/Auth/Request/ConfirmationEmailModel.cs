namespace Infrastructure.Models.Plans
{
    public class ConfirmationEmailModel
    {
        public required string UserId { get; set; }
        public required string Code { get; set; }

        public required string ChangedEmail { get; set; }
    }


}
