using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme, 
               Roles = AuthenticationConstants.OperationClaims.AdminStr)]
    public class HomeController : Controller
    {
        // .../admin/home/index
        public IActionResult Index()
        {
            return View();
        }
    }
}
