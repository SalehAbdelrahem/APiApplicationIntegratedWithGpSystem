using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Items
{
    public class Item
    {
        public string ITEMNMBR { get; set; }
        public string ITEMDESC { get; set; }
        public string ITMSHNAM { get; set; }
        public string ITMCLSCD { get; set; }
        public string ITMGEDSC { get; set; }
        public string UOMSCHDL { get; set; }
        public short ITEMTYPE { get; set; } // 1:5
        public short UpdateIfExists { get; set; }
        public static implicit operator taUpdateCreateItemRcd(Item item)
        {
            return new taUpdateCreateItemRcd
            {
                ITEMNMBR = item.ITEMNMBR,
                ITEMDESC = item.ITEMDESC,
                ITMSHNAM= item.ITMSHNAM,
                ITMGEDSC= item.ITMGEDSC,
                UOMSCHDL = item.UOMSCHDL,
                ITEMTYPE = item.ITEMTYPE,
                ITMCLSCD = item.ITMCLSCD,
                UseItemClass = 1,
                UpdateIfExists = item.UpdateIfExists
            };
        }
    }
}
