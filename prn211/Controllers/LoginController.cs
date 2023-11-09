using Microsoft.AspNetCore.Mvc;
using prn211.Models;

namespace prn211.Controllers
{
    public class LoginController : Controller
    {   
        prn211Context db = new prn211Context();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {   
                
                return View();
            }
            else
            {
                return RedirectToAction("list", "Admin");
            }
           
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var username = user.Username;
            var password = user.Password;
            
            if (HttpContext.Session.GetString("UserName") == null)
            {
				var u = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
				if (u != null)
                {
                   HttpContext.Session.SetString("loginid", u.Userid.ToString());
                   return RedirectToAction("list", "Admin");
                }
         
            }
            ViewBag.Error = "Invalid Account";
            return RedirectToAction("Index");
           
		}
        public IActionResult Logout()
        {
			HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
			return RedirectToAction("Index", "Login");
		}
    }
}
