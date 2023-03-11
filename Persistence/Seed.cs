using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Category 1",
                    Type = "Expense",
                    IsActive = true,
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory{ Name = "Subcategory 1", IsActive = true },
                        new SubCategory{ Name = "Subcategory 2", IsActive = true },
                        new SubCategory{ Name = "Subcategory 3", IsActive = true }
                    }
                },
                new Category
                {
                    Name = "Category 2",
                    Type = "Income",
                    IsActive = true,
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory{ Name = "Subcategory 4", IsActive = true },
                        new SubCategory{ Name = "Subcategory 5", IsActive = true },
                        new SubCategory { Name = "Subcategory 6", IsActive = true }
                    }
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}