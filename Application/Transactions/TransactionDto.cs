using Application.SubCategories;
using Application.User;

namespace Application.Transactions
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