using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Beis.RegisterYourInterest.Models
{
    public class ChooseYourAddressViewModel
    {
        public string? PostCode { get; set; }

        [Required(ErrorMessage = "Choose your address")]
        public string? UPRN { get; set; }

        public IEnumerable<SelectListItem> AddressList { get; set; } = new List<SelectListItem>();
    }
}
