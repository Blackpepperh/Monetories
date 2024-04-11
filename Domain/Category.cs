namespace Domain
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryGroup { get; set; }
        public bool IsActive { get; set; }
    }
}