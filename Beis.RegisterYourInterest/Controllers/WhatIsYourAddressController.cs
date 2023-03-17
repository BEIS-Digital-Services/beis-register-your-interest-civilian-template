using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class WhatIsYourAddressController : BaseController<WhatIsYourAddressViewModel>
    {
        private readonly IAddressLookupService _service;

        public WhatIsYourAddressController(ILogger<WhatIsYourAddressController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService, IAddressLookupService service) : base(logger, httpContextAccessor, sessionService)
        {
            _service = service;
        }

        [HttpGet(RoutePaths.WhatIsYourAddressPage, Name =RouteNames.WhatIsYourAddressPage)]
        public IActionResult Index()
        {
            return View(base.LoadDtoAndModelFromSession());
        }

        [ValidateAntiForgeryToken]
        [HttpPost(RoutePaths.WhatIsYourAddressPage, Name = RouteNames.WhatIsYourAddressPage)]
        public async Task<IActionResult> Index(WhatIsYourAddressViewModel model)
        {
            var addressList = await _service.LookupAddressListAsync(string.Empty, model.PostCode);

            model.LocalCustodianCode = addressList.FirstOrDefault()?.LocalCustodianCode;
            model.AddressNotFound = false;

            if (base.StoreDtoAndModelToSession(model).IsSuccess)
                return RedirectToRoute(RouteNames.ThankYouForYourInterestPage);
            else
                return View(nameof(Index), model);
        }

        public override WhatIsYourAddressViewModel MapDtoToModel(WhatIsYourAddressViewModel model)
        {
            if (dto.Address != null)
            {
                model.AddressLine1 = dto.Address.AddressLine1;
                model.AddressLine2 = dto.Address.AddressLine2;
                model.TownOrCity = dto.Address.Town;
                model.County = dto.Address.County;
                model.PostCode = dto.Address.Postcode;
                model.LocalCustodianCode = dto.Address.LocalCustodianCode;
            }

            model.AddressNotFound = dto.AddressNotFound;

            return model;
        }

        public override void MapModelToDto(WhatIsYourAddressViewModel model)
        {
            dto.Address ??= new AddressDto();
            dto.Address.AddressLine1 = model.AddressLine1;
            dto.Address.AddressLine2 = model.AddressLine2;
            dto.Address.Town = model.TownOrCity;
            dto.Address.County = model.County;
            dto.Address.Postcode = model.PostCode;
            dto.Address.LocalCustodianCode = model.LocalCustodianCode;
            dto.AddressNotFound = model.AddressNotFound;
        }
    }
}
