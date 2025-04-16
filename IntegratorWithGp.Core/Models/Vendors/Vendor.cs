using IntegratorWithGp.Core.Models.Customers;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Vendors
{
    public class Vendor
    {
        public string VENDORID { get; set; }
        public string VENDNAME { get; set; }
        public string VNDCLSID { get; set; }
        public string VADDCDPR { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string PHNUMBR1 { get; set; }
        public string TAXSCHID { get; set; }
        public string TXRGNNUM { get; set; }
        public string CURNCYID { get; set; }
        public short UpdateIfExists { get; set; }
        public static implicit operator taUpdateCreateVendorRcd(Vendor vendor)
        {
            return new taUpdateCreateVendorRcd
            {
                VENDORID = vendor.VENDORID,
                VENDNAME = vendor.VENDNAME,
                VNDCLSID = vendor.VNDCLSID,
                VADDCDPR = vendor.VADDCDPR,
                ADDRESS1 = vendor.ADDRESS1,
                ADDRESS2 = vendor.ADDRESS2,
                CITY = vendor.CITY,
                STATE = vendor.STATE,
                COUNTRY = vendor.COUNTRY,
                PHNUMBR1 = vendor.PHNUMBR1,
                TAXSCHID = vendor.TAXSCHID,
                TXRGNNUM = vendor.TXRGNNUM,
                CURNCYID = vendor.CURNCYID,
                UseVendorClass=1,
                UpdateIfExists = vendor.UpdateIfExists
            };
        }
    }
}
