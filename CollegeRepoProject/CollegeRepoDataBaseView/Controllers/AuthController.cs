using Microsoft.AspNetCore.Mvc;

namespace CollegeRepoDataBaseView.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
