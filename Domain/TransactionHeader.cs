namespace Domain
{
    public class TransactionHeader
    {
        public Guid TransactionHeaderId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalInAmount { get; set; }
        public decimal TotalOutAmount { get; set; }
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public ICollection<TransactionDetail> Categories { get; set; }
    }
}