using Beis.Common.Services.CompanyHouseApi;

namespace Beis.RegisterYourInterest.Models
{
    public class WebApplicationDto : ICookieBannerDto
	{
        public CookieBannerViewModel CookieBannerViewModel { get; set; }
        public bool? HasCompaniesHouseNumber { get;  set; }
        public string CompaniesHouseNumber { get; set; }
        public CompanyHouseResponse? CompanyHouseResponse { get; set; }
        public bool? HasFcaNumber { get; set; }
        public string FCAFullRegistrationNumber { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmailAddress { get; set; }
        public string ApplicantPhoneNumber { get; set; }
        public string ApplicantRole { get; set; }




        public string? PostCode { get; set; }
        public IEnumerable<AddressDto> AddressList { get; set; } = Enumerable.Empty<AddressDto>();
        public AddressDto? Address { get; set; }
        public bool? IsThisYourAddress { get; set; }
        public string? HouseNumber { get; set; }
        public bool AddressNotFound { get; set; }
    }
}
