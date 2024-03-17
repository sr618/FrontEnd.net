using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using proj0.DAL;
using proj0.Models;

namespace proj0.Controllers
{
    public class LoginController : Controller
    {
        private readonly Dal_User _dal;

        public LoginController(Dal_User dal)
        {
            _dal = dal;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Indexx(LoginModel mdl)
        {
            UserModel user = _dal.GetUserByCredentials(mdl.UserName, mdl.Password);
            if (user == null)
            {
                ViewBag.SweetAlertMessage = "Invalid Username or Password";
                ViewBag.SweetAlertType = "error";
                TempData["SweetAlertMessage"] = "Invalid Username or Password";
                TempData["SweetAlertType"] = "error";
                return RedirectToAction("Index");
            
            }
            else
            {
                // Log in user and redirect to home page
                HttpContext.Session.SetString("UserID", user.UserID.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                HttpContext.Session.SetString("IsActive", user.IsActive.ToString());
                HttpContext.Session.SetString("Image", user.Image);
                HttpContext.Session.SetString("address", user.address);
                HttpContext.Session.SetString("Password", user.Password);
                HttpContext.Session.SetString("Created", user.Created);
                HttpContext.Session.SetString("Modified", user.Modified);
                HttpContext.Session.SetString("Postcode", user.Pincode.ToString());

                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult Register()
        {
            return View();
        }

      
        public IActionResult Registerr(UserModel mdl)
        {
            if (ModelState.IsValid)
            {
                int result = _dal.AddUser(mdl);
                if (result > 0)
                {
                    // Registration successful
                    return RedirectToAction("Index");
                }
                else
                {
                    // Registration failed, display error message
                    ViewBag.SweetAlertMessage = "Failed to register user. Please try again later.";
                    ViewBag.SweetAlertType = "error";
                    TempData["SweetAlertMessage"] = "Failed to register user. Please try again later.";
                    TempData["SweetAlertType"] = "error";
                    return RedirectToAction("Register");
                }
            }
            else
            {
                // Model validation failed, display validation error messages
                ViewBag.SweetAlertMessage = "Please fix the following errors:";
                ViewBag.SweetAlertType = "error";
                TempData["SweetAlertMessage"] = "Please fix the following errors:";
                TempData["SweetAlertType"] = "error";
                return RedirectToAction("Register");
            }
        }

    }
}
