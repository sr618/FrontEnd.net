// CartController.cs
using Microsoft.AspNetCore.Mvc;
using proj0.Models;
using proj0.Services;
using proj0.Models;
using proj0.Services;

public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult AddToCart(int itemId)
    {
        var item = GetItemFromDatabase(itemId); // Retrieve item from the database
        _cartService.AddItemToCart(item);
        return RedirectToAction("Index", "Home"); // Redirect to home page or wherever you want
    }

    public IActionResult RemoveFromCart(int itemId)
    {
        _cartService.RemoveItemFromCart(itemId);
        return RedirectToAction("Index", "Home"); // Redirect to home page or wherever you want
    }

    private CartItem GetItemFromDatabase(int itemId)
    {
        // Logic to retrieve item from the database
        // This is just a placeholder, replace it with your actual implementation
        return new CartItem
        {
            ItemID = itemId,
            Name = "Sample Item",
            Description = "Sample Description",
            Image = "/path/to/image.jpg",
            Price = 10.99m
        };
    }
}
