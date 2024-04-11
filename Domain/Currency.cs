namespace Domain
{
    public class Currency
    {
        public Guid CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyOrigin { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Account> AppUsers { get; set; } = new List<Account>();
    }
}