using System.Formats.Asn1;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (userManager.Users.Any()) return;
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


            if (context.Categories.Any()) return;

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Category 1",
                    CategoryGroup = "Category Group 1",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 2",
                    CategoryGroup = "Category Group 1",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 3",
                    CategoryGroup = "Category Group 1",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 1",
                    CategoryGroup = "Category Group 2",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 1",
                    CategoryGroup = "Category Group 2",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 3",
                    CategoryGroup = "Category Group 2",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 2",
                    CategoryGroup = "Category Group 3",
                    IsActive = true
                },
                new Category
                {
                    CategoryName = "Category 4",
                    CategoryGroup = "Category Group 2",
                    IsActive = true
                },

            };

            if (context.Currencies.Any()) return;
            var currencies = new List<Currency>
            {
                new Currency
                {
                    CurrencyName = "Indonesia Rupiah",
                    CurrencyOrigin = "Indonesia",
                    CurrencySymbol = "Rp",
                    IsActive = true
                },
                new Currency
                {
                    CurrencyName = "Singapore Dollar",
                    CurrencyOrigin = "Singapore",
                    CurrencySymbol = "S$",
                    IsActive = true
                },
                new Currency
                {
                    CurrencyName = "US Dollar",
                    CurrencyOrigin = "United States",
                    CurrencySymbol = "$",
                    IsActive = true
                },
                new Currency
                {
                    CurrencyName = "Pound Sterling",
                    CurrencyOrigin = "United Kingdom",
                    CurrencySymbol = "£",
                    IsActive = false
                },
                new Currency
                {
                    CurrencyName = "Japanese Yen",
                    CurrencyOrigin = "Japan",
                    CurrencySymbol = "¥",
                    IsActive = false
                },
                new Currency
                {
                    CurrencyName = "Bitcoin",
                    CurrencyOrigin = "World Wide",
                    CurrencySymbol = "₿",
                    IsActive = false
                },
            };

            if (context.Accounts.Any()) return;

            var accounts = new List<Account>
            {
                new Account
                {
                    AccountName = "General Account",
                    IsActive = true,
                    AppUser = users[0],
                    Currency = currencies[0],
                },
                new Account
                {
                    AccountName = "General Account",
                    IsActive = true,
                    AppUser = users[1],
                    Currency = currencies[0],
                },
                new Account
                {
                    AccountName = "Investment Account",
                    IsActive = true,
                    AppUser = users[1],
                    Currency = currencies[0],
                },
                new Account
                {
                    AccountName = "Crypto Account",
                    IsActive = false,
                    AppUser = users[1],
                    Currency = currencies[5],
                },
            };

            if (context.TransactionHeaders.Any()) return;

            var transactionHeaders = new List<TransactionHeader>()
            {
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now,
                    TotalInAmount = 0,
                    TotalOutAmount = 500000,
                    Account = accounts[0],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-2),
                    TotalInAmount = 0,
                    TotalOutAmount = 100000,
                    Account = accounts[0],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-3),
                    TotalInAmount = 0,
                    TotalOutAmount = 550000,
                    Account = accounts[0],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-4),
                    TotalInAmount = 20000,
                    TotalOutAmount = 50000,
                    Account = accounts[0],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now,
                    TotalInAmount = 0,
                    TotalOutAmount = 300000,
                    Account = accounts[1],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-2),
                    TotalInAmount = 0,
                    TotalOutAmount = 13000,
                    Account = accounts[1],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-3),
                    TotalInAmount = 0,
                    TotalOutAmount = 24000,
                    Account = accounts[1],
                },
                new TransactionHeader
                {
                    TransactionDate = DateTime.Now.AddDays(-4),
                    TotalInAmount = 20000,
                    TotalOutAmount = 0,
                    Account = accounts[1],
                },
            };


            await context.Currencies.AddRangeAsync(currencies);
            await context.Categories.AddRangeAsync(categories);
            await context.Accounts.AddRangeAsync(accounts);
            await context.TransactionHeaders.AddRangeAsync(transactionHeaders);
            await context.SaveChangesAsync();
        }
    }
}