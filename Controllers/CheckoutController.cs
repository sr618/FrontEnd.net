using Microsoft.AspNetCore.Mvc;

namespace proj0.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
