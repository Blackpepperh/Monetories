namespace Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}