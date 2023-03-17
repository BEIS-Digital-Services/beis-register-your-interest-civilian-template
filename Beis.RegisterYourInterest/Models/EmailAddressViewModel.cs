﻿
using DataAnnotationsExtensions;

namespace Beis.RegisterYourInterest.Models
{
    public class EmailAddressViewModel
    {
        [Required(ErrorMessage = "Enter your email address")] 
        [Email( ErrorMessage = "Enter your email address")]  
        public string EmailAddress { get; set; }
    } 
}