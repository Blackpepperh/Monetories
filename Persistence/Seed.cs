using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

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
                        },
                    new AppUser{
                        DisplayName = "Oli Si Sapi",
                        BirthPlace ="Jakarta",
                        BirthDate = "2023-05-22",
                        UserName = "oli",
                        PhoneNumber = "089777171",
                        IsActive = false,
                        Email = "oli@gmail.com",
                        },

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
                    IsActive = true
                },
                new Category
                {
                    Name = "Category 2",
                    Type = "Income",
                    IsActive = true
                },
                new Category
                {
                    Name = "Category 3",
                    Type = "Income",
                    IsActive = false
                }
            };

            if (context.SubCategories.Any()) return;

            var subCategories = new List<SubCategory>
            {
                new SubCategory
                    {
                        Name = "Sub Category 1",
                        IsActive = true,
                        Category = categories[0],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 2",
                        IsActive = true,
                        Category = categories[0],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 3",
                        IsActive = false,
                        Category = categories[0],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 4",
                        IsActive = false,
                        Category = categories[0],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 5",
                        IsActive = true,
                        Category = categories[1],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 6",
                        IsActive = true,
                        Category = categories[1],
                    },
                new SubCategory
                    {
                        Name = "Sub Category 7",
                        IsActive = true,
                        Category = categories[1],
                    }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SubCategories.AddRangeAsync(subCategories);
            await context.SaveChangesAsync();
        }
    }
}