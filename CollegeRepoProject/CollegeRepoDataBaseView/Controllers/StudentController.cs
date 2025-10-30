using Microsoft.AspNetCore.Mvc;

namespace CollegeRepoDataBaseView.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
