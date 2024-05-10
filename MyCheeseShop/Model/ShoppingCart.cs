using System.Numerics;




namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<OrderItem> Items;

        public ShoppingCart()
        {
            Items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            // add the cheese or increase the quantity
            var item = Items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is null)
                Items.Add(new OrderItem { Cheese = cheese, Quantity = quantity });
            else
                item.Quantity += quantity;

            // alert the listeners to the cart change
            OnCartUpdated?.Invoke();
        }

        public int Count()
        {
            // return the number of items in the cart
            return Items.Count;
        }

        public decimal Total()
        {
            // sum the price of all items in the cart
            return Items.Sum(item => item.Cheese.Price * item.Quantity);
        }

        public IEnumerable<OrderItem> GetItems()
        {
            // return a copy of the items in the cart
            return Items;
        }

        public void RemoveItem(Cheese cheese)
        {
            // remove the cheese from the cart
            Items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    Items.Remove(item);
            }
            OnCartUpdated?.Invoke();
        }

        public void Clear()
        {
            // remove all items from the cart
            Items.Clear();
            OnCartUpdated?.Invoke();
        }

        public int GetQuantity(Cheese cheese)
        {
            // return the quantity of the cheese in the cart
            var item = Items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }

        public void SetItems(IEnumerable<OrderItem> items)
        {
            // set the items in the cart
            Items = items.ToList();
            OnCartUpdated?.Invoke();
        }
    }
}
