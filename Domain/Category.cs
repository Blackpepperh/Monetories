namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public List<SubCategory> SubCategories { get; set; }

    }
}