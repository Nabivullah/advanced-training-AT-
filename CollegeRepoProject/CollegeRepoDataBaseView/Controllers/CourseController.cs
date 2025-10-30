using Microsoft.AspNetCore.Mvc;

namespace CollegeRepoDataBaseView.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
