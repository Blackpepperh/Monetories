namespace Domain
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public bool IsActive { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public Currency Currency { get; set; }
        public Guid CurrencyId { get; set; }
        public ICollection<TransactionHeader> TransactionHeaders { get; set; } = new List<TransactionHeader>();
    }
}