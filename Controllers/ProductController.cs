using Microsoft.AspNetCore.Mvc;
using proj0.Models;

namespace proj0.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int? id)
        {

            if (id>0 && id.HasValue)
            {
                DAL.DAL_Items dl = new DAL.DAL_Items();
                var x = dl.GetItems();
                ItemModel itm = x.Find(i => i.ItemID == id);
                return View(itm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
       
        public IActionResult ProductsByCategory(int? categoryId)
        {
            int? id = (int)categoryId;
            if (id > 0 && id.HasValue)
            {
                DAL.DAL_Items dl = new DAL.DAL_Items();
                var x = dl.GetItems();
                var itm = x.FindAll(i => i.CategoryID == id);
                return View(itm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Allitems()
        {
            DAL.DAL_Items dl = new DAL.DAL_Items();
            var x = dl.GetItems();
            return View(x);
        }
    }
}
