using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Transaction> SubCategories { get; set; } = new List<Transaction>();
        public ICollection<Account> Currencies { get; set; } = new List<Account>();

    }
}