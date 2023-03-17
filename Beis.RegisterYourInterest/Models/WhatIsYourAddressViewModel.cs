using System.ComponentModel.DataAnnotations;

namespace Beis.RegisterYourInterest.Models
{

    public class WhatIsYourAddressViewModel
    {
        [Required(ErrorMessage = "Enter the first line of your address")]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [Required(ErrorMessage = "Enter your town or city")]
        public string TownOrCity { get; set;}
        public string? County { get; set;}
        [Required(ErrorMessage = "Enter your postcode, like AA1 1AA")]
        public string PostCode { get; set;}

        public int? LocalCustodianCode { get; set; }

        public bool AddressNotFound { get; set; }
    }
}
