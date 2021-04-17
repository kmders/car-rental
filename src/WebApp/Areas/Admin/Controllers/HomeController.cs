using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        // .../admin/home/index
        public IActionResult Index()
        {
            return View();
        }
    }
}
