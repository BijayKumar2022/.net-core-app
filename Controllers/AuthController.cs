using Microsoft.AspNetCore.Mvc;

namespace custumcore.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                if (login.first_name.ToLower() == "admin" && login.Password == "admin")
                {
                    Session["first_name"] = login.first_name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(login);
                }

            }
            return View(login);
        }
    }
}
