using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{
                        DisplayName = "Hendro Ang Handaka",
                        BirthPlace ="Pekanbaru",
                        BirthDate = "1995-07-04",
                        UserName = "Hendro",
                        PhoneNumber = "08972180181",
                        IsActive = true,
                        Email = "hhendro.ang@gmail.com",
                        },
                    new AppUser{
                        DisplayName = "Silvia Anggelina",
                        BirthPlace ="Pekanbaru",
                        BirthDate = "1998-05-26",
                        UserName = "Silvia",
                        PhoneNumber = "08991200505",
                        IsActive = true,
                        Email = "wuaicia@gmail.com",
                        }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "password");
                }
            }


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