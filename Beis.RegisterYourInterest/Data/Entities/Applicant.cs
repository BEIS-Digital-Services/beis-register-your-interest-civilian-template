using Beis.Common.Entities.Models;
using Beis.Common.Services.CompanyHouseApi;
using Beis.RegisterYourInterest.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Beis.RegisterYourInterest.Data.Entities
{}
namespace Beis.RegisterYourInterest.Data
{
    //[Table("applicant")]
    public class Applicant : BaseUserEntity
    {        
        public string applicant_phone_number { get; set; }
        //public string applicant_address { get; set; }
        public Address address { get; set; }
        public int address_id { get; set; }

    }
}
