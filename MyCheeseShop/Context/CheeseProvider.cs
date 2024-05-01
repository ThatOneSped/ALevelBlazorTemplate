using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using System.Threading.Tasks;

namespace MyCheeseShop.Context
{
    public class CheeseProvider
    {
        private readonly DatabaseContext _context;
        public CheeseProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Cheese>> GetAllCheesesAsync()
        {
            return await _context.Cheeses.OrderBy(CheeseProvider => CheeseProvider.Name).ToListAsync();
        }
        public Cheese? GetCheese(int id)
        {
            return _context.Cheeses.Find(id);
        }
    }

}
