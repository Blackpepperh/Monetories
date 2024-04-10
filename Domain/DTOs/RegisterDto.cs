using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^.{8,}$", ErrorMessage = "Password must be more than 8 characters")]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}