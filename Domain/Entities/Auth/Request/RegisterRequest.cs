using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Auth.Request
{

    public class RegisterRequest
    {

        //[Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string? name { get; set; } = "Name";

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public required string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public required string password { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        public required string phoneNumber { get; set; }   
        
        public required string userRole { get; set; }

    }


}
