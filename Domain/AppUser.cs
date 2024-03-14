using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Transaction> SubCategory { get; set; } = new List<Transaction>();

    }
}