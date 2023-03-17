
using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class ConfirmAddressController : BaseController<ConfirmAddressViewModel>
    {
        public ConfirmAddressController(ILogger<ConfirmAddressController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {}

        public override ConfirmAddressViewModel MapDtoToModel(ConfirmAddressViewModel model)
        {
            model.IsThisYourAddress = dto.IsThisYourAddress;
            model.Address = dto.AddressList.Single().ToString();
            return model;
        }

        public override void MapModelToDto(ConfirmAddressViewModel model)
        {
            dto.IsThisYourAddress = model.IsThisYourAddress;

            dto.Address = dto.IsThisYourAddress ?? false
                ? dto.AddressList.Single()
                : null;
        }

        [HttpGet(RoutePaths.ConfirmAddressPage, Name = RouteNames.ConfirmAddressPage)]
        public  IActionResult Index()
        {
            var model = base.LoadDtoAndModelFromSession();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost(RoutePaths.ConfirmAddressPage, Name = RouteNames.ConfirmAddressPage)]
        public IActionResult Index(ConfirmAddressViewModel model)
        {
            var result = base.StoreDtoAndModelToSession(model);
            if (result.IsSuccess)
                if(model.IsThisYourAddress.GetValueOrDefault())
                    return RedirectToRoute(RouteNames.ConfirmEmailAddressPage);
                else 
                    return RedirectToRoute(RouteNames.WhatIsYourAddressPage);
            else
                return View(nameof(Index), model);
        }
    }
}
