using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace proj0.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckoutController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            // Check if the user is logged in
            if (!_httpContextAccessor.HttpContext.Session.Keys.Contains("UserID"))
            {
                // User is not logged in, redirect to the login page
                return RedirectToAction("Index", "Login"); // Assuming your login page is named "Login" in the "Account" controller
            }

            return View();
        }
    }
}
