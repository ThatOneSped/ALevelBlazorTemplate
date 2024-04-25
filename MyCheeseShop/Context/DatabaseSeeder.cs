using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }

            if (!_context.Users.Any()) 
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };


                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        private List<Cheese> GetCheeses()
        {
            return
                [
                    new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 9.99m },
                    new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = 12.50m },
                    new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 11.75m },
                    new Cheese { Name = "Parmesan", Type = "Hard", Description = "Aged and granular", Strength = "Strong", Price = 15.25m },
                    new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 8.99m },
                    new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and pungent", Strength = "Strong", Price = 18.75m },
                    new Cheese { Name = "Camembert", Type = "Soft", Description = "Rich and creamy", Strength = "Mild", Price = 14.99m },
                    new Cheese { Name = "Gruyère", Type = "Hard", Description = "Sweet and salty", Strength = "Medium", Price = 13.50m },
                    new Cheese { Name = "Manchego", Type = "Hard", Description = "Nutty and slightly salty", Strength = "Medium", Price = 17.50m },
                    new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 10.99m },
                ];
        }
    }
}
