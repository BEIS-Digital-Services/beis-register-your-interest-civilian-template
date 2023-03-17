using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beis.RegisterYourInterest.Controllers
{
    public class ChooseYourAddressController : BaseController<ChooseYourAddressViewModel>
    {
        public ChooseYourAddressController(ILogger<ChooseYourAddressController> logger, ISessionService sessionService, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor, sessionService)
        {}

        public override ChooseYourAddressViewModel MapDtoToModel(ChooseYourAddressViewModel model)
        {
            model.PostCode = dto.PostCode;
            model.AddressList = dto.AddressList.Select(x => new SelectListItem(x.ToString(), x.UPRN));
            return model;
        }

        public override void MapModelToDto(ChooseYourAddressViewModel model)
        {
            dto.Address = dto.AddressList.SingleOrDefault(x => x.UPRN == model.UPRN);
        }

        [HttpGet(RoutePaths.ChooseYourAddressPage, Name = RouteNames.ChooseYourAddressPage)]
        public IActionResult Index()
        {
            var model = base.LoadDtoAndModelFromSession();
            return View(model);
        }

        [HttpPost(RoutePaths.ChooseYourAddressPage, Name = RouteNames.ChooseYourAddressPage)]
        public IActionResult Index(ChooseYourAddressViewModel model)
        {
            var result = base.StoreDtoAndModelToSession(model);
            if (result.IsSuccess)
                return RedirectToRoute(RouteNames.ThankYouForYourInterestPage);
            else
                return View(nameof(Index), model);
        }
    }
}
