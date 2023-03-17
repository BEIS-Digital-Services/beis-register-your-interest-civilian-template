using Beis.RegisterYourInterest.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class FindYourAddressController : BaseController<FindYourAddressViewModel>
    {
        private readonly IAddressLookupService _client;

        public FindYourAddressController(ILogger<FindYourAddressController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService, IAddressLookupService client) : base(logger, httpContextAccessor, sessionService)
        {
            _client = client;
        }

        public override FindYourAddressViewModel MapDtoToModel(FindYourAddressViewModel model)
        {
            model.HouseNumber = dto.HouseNumber;
            model.PostCode = dto.PostCode;
            model.AddressList = dto.AddressList;
            return model;
        }

        public override void MapModelToDto(FindYourAddressViewModel model)
        {
            dto.HouseNumber = model.HouseNumber;
            dto.PostCode = model.PostCode;
            dto.AddressList = model.AddressList;
            dto.AddressNotFound = model.AddressNotFound;
        }

        [HttpGet(RoutePaths.FindYourAddressPage, Name = RouteNames.FindYourAddressPage)]
        public IActionResult Index()
        {
            TempData["PreviousPage"] = Request.GetPreviousPage();
            return View(base.LoadDtoAndModelFromSession());
        }

        [HttpPost(RoutePaths.FindYourAddressPage, Name = RouteNames.FindYourAddressPage)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FindYourAddressViewModel model)
        {
            var addressList = await _client.LookupAddressListAsync(model.HouseNumber, model.PostCode);

            if (addressList == null || !addressList.Any())
            {
                model.AddressNotFound = true;
                StoreDtoAndModelToSession(model);
                return RedirectToRoute(RouteNames.WhatIsYourAddressPage);
            }

            model.AddressList = addressList.Select(x => new AddressDto
            {
                UPRN = x.UPRN,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Town = x.Town,
                Postcode = x.PostCode,
                LocalCustodianCode = x.LocalCustodianCode
            });

            if (base.StoreDtoAndModelToSession(model).IsSuccess)
                return RedirectToRoute(
                    addressList.Count() > 1
                        ? RouteNames.ChooseYourAddressPage
                        : RouteNames.ConfirmAddressPage);
            else
                return View(nameof(Index), model);
        }
    }
}
