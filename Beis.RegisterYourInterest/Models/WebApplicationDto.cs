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
        public string? PostCode { get; internal set; }
        public IEnumerable<AddressDto> AddressList { get; internal set; }
        public AddressDto? Address { get; internal set; }
        public bool? IsThisYourAddress { get; internal set; }
        public string? HouseNumber { get; internal set; }
        public bool AddressNotFound { get; internal set; }
    }
}
