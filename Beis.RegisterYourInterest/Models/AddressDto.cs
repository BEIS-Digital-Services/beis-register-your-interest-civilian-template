using Beis.RegisterYourInterest.Data.Entities;

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

        public Address ToEntity()
        {
            return new Address
            {
                uprn = UPRN,
                address_line_1 = AddressLine1,
                address_line_2 = AddressLine2,
                town = Town,
                county = County,
                postcode = Postcode,
                custodian_code = LocalCustodianCode
            };
        }

        public static AddressDto FromEntity(Address entity)
        {
            var dto = new AddressDto
            {
                UPRN = entity.uprn,
                AddressLine1 = entity.address_line_1,
                AddressLine2 = entity.address_line_2,
                Town = entity.town,
                County = entity.county,
                Postcode = entity.postcode,
                LocalCustodianCode = entity.custodian_code
            };
            return dto;
        }
    }
}
