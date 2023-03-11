namespace Domain
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Category Category { get; set; }
    }
}