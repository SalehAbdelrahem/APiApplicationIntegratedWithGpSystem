using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.ItemVendors
{
    public class ItemVendor
    {
        public string VENDORID { get; set; }
        public string ITEMNMBR { get; set; }
        public string VNDITNUM { get; set; }

        public static implicit operator taCreateItemVendors_ItemsTaCreateItemVendors(ItemVendor itemVendor) =>
        new taCreateItemVendors_ItemsTaCreateItemVendors
        {
            VENDORID = itemVendor.VENDORID,
            ITEMNMBR = itemVendor.ITEMNMBR,
            VNDITNUM = itemVendor.VNDITNUM,
            UpdateIfExists = 1
        };

    }
}
