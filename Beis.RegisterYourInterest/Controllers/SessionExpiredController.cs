﻿
namespace Beis.RegisterYourInterest.Controllers
{
    public class SessionExpiredController : Controller
    {
        public SessionExpiredController()
        {

        }

        [Route(RoutePaths.SessionExpiredPage, Name = RouteNames.SessionExpiredPage)]
        public IActionResult Index()
        {
            return View();
        }
    }
}