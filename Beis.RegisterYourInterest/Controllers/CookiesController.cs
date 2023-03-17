
using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class CookiesController : Controller
    {
        public CookiesController()
        {
        }

        [HttpGet(RoutePaths.CookiesPage, Name = RouteNames.CookiesPage)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
