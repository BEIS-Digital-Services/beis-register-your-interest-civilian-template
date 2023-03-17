namespace Beis.RegisterYourInterest.Models
{
    public class AddressDto
    {
        public string UPRN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public int? LocalCustodianCode { get; set; }

        public override string ToString()
        {
            return string.Join(", ", new[] { AddressLine1, AddressLine2, Town, County, Postcode }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }
    }
}
