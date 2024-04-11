namespace Domain
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Transaction> AppUsers { get; set; } = new List<Transaction>();
    }
}