namespace Domain.DTOs
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public bool IsActive { get; set; }
        public AppUserDto AppUser { get; set; }
        public CurrencyDto Currency { get; set; }

    }
}