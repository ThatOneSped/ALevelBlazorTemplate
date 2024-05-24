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
                    new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 9.99m, ImageUrl = "cheddar.png" },
                    new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = 12.50m, ImageUrl = "brie.png" },
                    new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 11.75m, ImageUrl = "gouda.png" },
                    new Cheese { Name = "Parmesan", Type = "Hard", Description = "Aged and granular", Strength = "Strong", Price = 15.25m, ImageUrl = "parmesan.png" },
                    new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 8.99m, ImageUrl = "mozzarela.png" },
                    new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and pungent", Strength = "Strong", Price = 18.75m, ImageUrl = "roquefort.png"},
                    new Cheese { Name = "Camembert", Type = "Soft", Description = "Rich and creamy", Strength = "Mild", Price = 14.99m, ImageUrl = "camembert.png" },
                    new Cheese { Name = "Gruyère", Type = "Hard", Description = "Sweet and salty", Strength = "Medium", Price = 13.50m, ImageUrl = "gruyére.png" },
                    new Cheese { Name = "Manchego", Type = "Hard", Description = "Nutty and slightly salty", Strength = "Medium", Price = 17.50m, ImageUrl = "manchego"},
                    new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 10.99m, ImageUrl = "feta.png" },
                    new Cheese { Name = "Blue Stilton", Type = "Blue", Description = "Rich and creamy with a pungent aroma", Strength = "Strong", Price = 19.99m },
                    new Cheese { Name = "Asiago", Type = "Hard", Description = "Fruity and sharp", Strength = "Medium", Price = 14.99m },
                    new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = 9.50m },
                    new Cheese { Name = "Emmental", Type = "Hard", Description = "Nutty and mild with holes", Strength = "Medium", Price = 16.00m },
                    new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Tangy and crumbly", Strength = "Strong", Price = 20.50m },
                    new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery and smooth", Strength = "Mild", Price = 11.99m },
                    new Cheese { Name = "Pecorino Romano", Type = "Hard", Description = "Salty and sharp", Strength = "Strong", Price = 18.00m },
                    new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Smooth and mild", Strength = "Medium", Price = 13.00m },
                    new Cheese { Name = "Ricotta", Type = "Soft", Description = "Mild and creamy", Strength = "Mild", Price = 7.50m },
                    new Cheese { Name = "Taleggio", Type = "Semi-soft", Description = "Tangy and fruity", Strength = "Medium", Price = 15.75m },
                    new Cheese { Name = "Halloumi", Type = "Semi-hard", Description = "Salty and brined", Strength = "Medium", Price = 12.25m },
                    new Cheese { Name = "Fontina", Type = "Semi-soft", Description = "Mild and nutty", Strength = "Medium", Price = 17.25m },
                    new Cheese { Name = "Jarlsberg", Type = "Semi-soft", Description = "Sweet and nutty", Strength = "Mild", Price = 14.00m },
                    new Cheese { Name = "Limburger", Type = "Soft", Description = "Pungent and creamy", Strength = "Strong", Price = 16.50m },
                    new Cheese { Name = "Munster", Type = "Semi-soft", Description = "Smooth and mild", Strength = "Medium", Price = 13.75m },
                    new Cheese { Name = "Paneer", Type = "Soft", Description = "Mild and fresh", Strength = "Mild", Price = 8.50m },
                    new Cheese { Name = "Queso Blanco", Type = "Semi-soft", Description = "Mild and milky", Strength = "Mild", Price = 9.99m },
                    new Cheese { Name = "Red Leicester", Type = "Hard", Description = "Rich and nutty", Strength = "Medium", Price = 15.00m },
                    new Cheese { Name = "Sainte-Maure de Touraine", Type = "Soft", Description = "Tangy and goat's milk", Strength = "Medium", Price = 21.00m },
                    new Cheese { Name = "Tilsit", Type = "Semi-hard", Description = "Buttery and tangy", Strength = "Medium", Price = 12.75m },
                    new Cheese { Name = "Wensleydale", Type = "Semi-hard", Description = "Crumbly and mild", Strength = "Mild", Price = 14.25m },
                    new Cheese { Name = "Raclette", Type = "Semi-hard", Description = "Mild and nutty", Strength = "Medium", Price = 16.99m },
                    new Cheese { Name = "Ricotta Salata", Type = "Semi-hard", Description = "Salty and firm", Strength = "Medium", Price = 11.50m },
                    new Cheese { Name = "Reblochon", Type = "Soft", Description = "Creamy and nutty", Strength = "Medium", Price = 18.25m },
                    new Cheese { Name = "Stinking Bishop", Type = "Soft", Description = "Pungent and creamy", Strength = "Strong", Price = 23.50m },
                    new Cheese { Name = "Neufchâtel", Type = "Soft", Description = "Creamy and slightly crumbly", Strength = "Mild", Price = 13.75m },
                    new Cheese { Name = "Double Gloucester", Type = "Hard", Description = "Rich and buttery", Strength = "Medium", Price = 15.25m },
                    new Cheese { Name = "Brillat-Savarin", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = 22.50m },
                    new Cheese { Name = "Crottin de Chavignol", Type = "Soft", Description = "Goaty and tangy", Strength = "Medium", Price = 20.00m },
                    new Cheese { Name = "Mahon", Type = "Hard", Description = "Sharp and buttery", Strength = "Medium", Price = 18.00m },
                    new Cheese { Name = "Roncal", Type = "Hard", Description = "Nutty and piquant", Strength = "Medium", Price = 19.50m },
                    new Cheese { Name = "Queso de Valdeón", Type = "Blue", Description = "Strong and piquant", Strength = "Strong", Price = 24.00m },
                    new Cheese { Name = "Requesón", Type = "Soft", Description = "Mild and fresh", Strength = "Mild", Price = 7.75m },
                    new Cheese { Name = "Teleme", Type = "Semi-soft", Description = "Mild and tangy", Strength = "Mild", Price = 12.99m },
                    new Cheese { Name = "Pont-l'Évêque", Type = "Soft", Description = "Creamy and pungent", Strength = "Medium", Price = 17.75m },
                    new Cheese { Name = "Fiore Sardo", Type = "Hard", Description = "Smoky and sharp", Strength = "Strong", Price = 21.99m },
                    new Cheese { Name = "Epoisses", Type = "Soft", Description = "Pungent and creamy", Strength = "Strong", Price = 25.50m },
                    new Cheese { Name = "Garrotxa", Type = "Semi-hard", Description = "Nutty and earthy", Strength = "Medium", Price = 19.99m },
                    new Cheese { Name = "Kasseri", Type = "Semi-hard", Description = "Buttery and tangy", Strength = "Medium", Price = 13.50m },
                ];  
        }
    }
}
