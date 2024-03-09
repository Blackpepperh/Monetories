namespace API.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }

    }
}