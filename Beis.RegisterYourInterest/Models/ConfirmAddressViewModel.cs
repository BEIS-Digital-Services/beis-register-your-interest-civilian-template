using System.ComponentModel.DataAnnotations;

namespace Beis.RegisterYourInterest.Models
{
    public class ConfirmAddressViewModel
    {
        public string? Address { get; set; }

        [Required(ErrorMessage = "Confirm your address")]        
        public bool? IsThisYourAddress { get; set; }
    }
}
