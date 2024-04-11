namespace Domain.DTOs
{
    public class TransactionHeaderDto
    {
        public Guid TransactionHeaderId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalInAmount { get; set; }
        public decimal TotalOutAmount { get; set; }
        public AccountDto Account { get; set; }
    }
}