// CartService.cs
using proj0.Models;
using System.Collections.Generic;
using System.Linq;

namespace proj0.Services
{
    public class CartService
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public void AddItemToCart(CartItem item)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.ItemID == item.ItemID);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cartItems.Add(item);
                item.Quantity = 1;
            }
        }

        public void RemoveItemFromCart(int itemId)
        {
            var itemToRemove = _cartItems.FirstOrDefault(i => i.ItemID == itemId);
            if (itemToRemove != null)
            {
                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    _cartItems.Remove(itemToRemove);
                }
            }
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public decimal CalculateTotal()
        {
            return _cartItems.Sum(item => item.Price * item.Quantity);
        }
    }
}
