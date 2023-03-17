using static System.Net.Mime.MediaTypeNames;

namespace Beis.RegisterYourInterest.Data.Entities
{
    public class Address
    {
        [Key]
        public int address_id { get; set; }
        public string? uprn { get; set; }
        public string? address_line_1 { get; set; }
        public string? address_line_2 { get; set; }
        public string? town { get; set; }
        public string? county { get; set; }
        public string? postcode { get; set; }
        public int? custodian_code { get; set; }
       
       
    }
}
