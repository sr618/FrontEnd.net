    using proj0.Models;
    using System.Linq; // Add this namespace for LINQ extensions

    namespace proj0.BAL
    {
        public class Cart
        {
            public List<CartItem> Items { get; set; } = new List<CartItem>();

            // Method to add item to cart
            public List<CartItem> AddItem(CartItem item)
            {
                // Check if item already exists in cart
                var existingItem = Items.FirstOrDefault(x => x.ItemID == item.ItemID);
                CalculateTotal();
                item.total = Total;
                if (existingItem != null)
                {
                    // Update quantity if item already exists
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    // Add new item to cart
                    Items.Add(item);
                }
                return Items;

                // Recalculate total
           
            }

            // Method to remove item from cart
            public List<CartItem> RemoveItem(int itemId)
            {
                var itemToRemove = Items.FirstOrDefault(x => x.ItemID == itemId);
                if (itemToRemove != null)
                {
                    CalculateTotal();
                    //add total to item
                    itemToRemove.total = Total;
                    Items.Remove(itemToRemove);
                    // Recalculate total
               
                }
                return Items;
            }

            // Method to calculate total
            private void CalculateTotal()
            {
                 Total = Items.Sum(item => item.Price * item.Quantity);
                // Set the total propert
            
            }

            // Total property
            decimal Total;
        }
    }
