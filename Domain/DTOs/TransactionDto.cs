namespace Domain.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public SubCategoryDto SubCategory { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}