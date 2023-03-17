using System.ComponentModel.DataAnnotations;

namespace Beis.RegisterYourInterest.Models
{
    public class FindYourAddressViewModel
    {
        public string? HouseNumber { get; set; }

        [Required(ErrorMessage = "Enter your postcode, like AA1 1AA")]
        [RegularExpression("([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\\s?[0-9][A-Za-z]{2})", ErrorMessage = "Enter your postcode, like AA1 1AA")]
        public string? PostCode { get; set; }

        public bool AddressNotFound { get; set; }

        public IEnumerable<AddressDto> AddressList { get; set; } = new List<AddressDto>();
    }
}
