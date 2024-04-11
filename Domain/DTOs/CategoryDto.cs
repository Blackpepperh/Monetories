namespace Domain.DTOs
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryGroup { get; set; }
        public bool IsActive { get; set; }
    }
}