using Microsoft.AspNetCore.Mvc;
using proj0.DAL;
using proj0.Models;

namespace proj0.Controllers
{
    public class LoginController : Controller
    {
        int UserID;
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Indexx(LoginModel mdl)
        {
            Dal_User dal
                = new Dal_User();
            UserModel users = dal.GetAllUsers().Find(x => x.UserName == mdl.UserName && x.Password == mdl.Password);
            if (users == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                UserID = users.UserID;
                //set sessions for user 
                HttpContext.Session.SetString("UserID", users.UserID.ToString());
                HttpContext.Session.SetString("UserName", users.UserName);
                HttpContext.Session.SetString("IsAdmin", users.IsAdmin.ToString());
                HttpContext.Session.SetString("IsActive", users.IsActive.ToString());
                //HttpContext.Session.SetString("Email", users.Email);
                HttpContext.Session.SetString("Image", users.Image);
                HttpContext.Session.SetString("address", users.address);
                HttpContext.Session.SetString("Password", users.Password);
                HttpContext.Session.SetString("Created", users.Created);
                HttpContext.Session.SetString("Modified", users.Modified);
                HttpContext.Session.SetString("Postcode", users.Pincode.ToString());

                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Register()
        {
          
                return View();
            
        }
     
        public IActionResult Registerr(UserModel mdl)
        {
            if (mdl.UserName != null && mdl.Password!=null)
            {
                Dal_User dal = new Dal_User();
                dal.AddUser(mdl);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
