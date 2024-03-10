using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using proj0.BAL;
using proj0.DAL;
using proj0.Models;
using System.Diagnostics;

namespace proj0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DAL_Items dl = new DAL_Items();
            DAL_Category dal = new DAL_Category();
            var x = new Multi
            {
                Categories = dal.GetallCategories(),
               Items = dl.GetItems()
            };
            return View(x);
     
        }

        public IActionResult AddToCart(string idx)
        {
            int id = int.Parse(idx); // Convert string id to int
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart(); // Retrieve or create a new cart from session

            // Get the item from DAL_Items by id
            DAL_Items dl = new DAL_Items();
            var item = dl.GetItems().Find(x => x.ItemID == id);

            // If the item exists, add it to the cart
            if (item != null)
            {
                // Create a new CartItem based on the retrieved item
                CartItem cartItem = new CartItem
                {
                    ItemID = item.ItemID,
                    Name = item.Name,
                    Price = (decimal)item.FinalPrice,
                    Quantity = 1 // Assuming initial quantity is 1, you can adjust this based on your logic
                };

                // Add the cartItem to the cart
                cart.AddItem(cartItem);

                // Save the cart back to session
                HttpContext.Session.Set("Cart", cart);
            }

            // Return a partial view containing the updated cart data
            return PartialView("_Cart", cart.Items);
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            cart.RemoveItem(productId);
            HttpContext.Session.Set("Cart", cart);

            // Return a partial view containing the updated cart data
            return PartialView("_Cart", cart.Items);
        }

    }
}
