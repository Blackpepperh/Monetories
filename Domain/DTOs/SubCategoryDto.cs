namespace Domain.DTOs
{
    public class SubCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public CategoryDto Category { get; set; }
    }
}