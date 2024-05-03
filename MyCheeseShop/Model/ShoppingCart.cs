using System.Numerics;

namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public void AddItem(Cheese cheeses, int quantity)
        {
            //adding cheese to cart
            var item = Items.FirstOrDefault(item => item.Cheese.Id == cheeses.Id);
            if (item is null)
                Items.Add(new OrderItem { Cheese = cheeses, Quantity = quantity });
            else //if item already in cart, add 1
                item.Quantity += quantity;
        }

        public int GetItems(Cheese cheeses)
        {
            var item = Items.FirstOrDefault(item => item.Cheese.Id == cheeses.Id);
            return item?.Quantity ?? 0;
        }
    }
}
