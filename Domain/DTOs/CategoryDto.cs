namespace Domain.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}