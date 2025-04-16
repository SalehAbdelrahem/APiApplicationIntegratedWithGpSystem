using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Customers
{
    public class Customer
    {
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string CUSTCLAS { get; set; }
        public string ADRSCODE { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string PHNUMBR1 { get; set; }
        public string TAXSCHID { get; set; }
        public string SLPRSNID { get; set; }
        public string TXRGNNUM { get; set; }
        public string CURNCYID { get; set; }
        public short UpdateIfExists { get; set; }
        public static implicit operator taUpdateCreateCustomerRcd(Customer customer)
        {
            return new taUpdateCreateCustomerRcd
            {
                CUSTNMBR = customer.CUSTNMBR,
                CUSTNAME = customer.CUSTNAME,
                CUSTCLAS = customer.CUSTCLAS,
                ADRSCODE = customer.ADRSCODE,
                ADDRESS1 = customer.ADDRESS1,
                ADDRESS2 = customer.ADDRESS2,
                CITY = customer.CITY,
                STATE = customer.STATE,
                COUNTRY = customer.COUNTRY,
                PHNUMBR1 = customer.PHNUMBR1,
                TAXSCHID = customer.TAXSCHID,
                SLPRSNID = customer.SLPRSNID,
                TXRGNNUM = customer.TXRGNNUM,
                CURNCYID = customer.CURNCYID,
                UseCustomerClass = 1,
                UpdateIfExists = customer.UpdateIfExists
            };
        }
    }
}
