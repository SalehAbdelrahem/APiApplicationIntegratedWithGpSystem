using System;
using IntegratorWithGp.Core.Enums;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Newtonsoft.Json;

namespace IntegratorWithGp.Core.Models.ReceivingTransactions
{
    public class POPLine
    {
        public short  POPTYPE { get; set; }
        public string POPRCTNM { get; set; }
        public string ITEMNMBR { get; set; }
        public string VENDORID { get; set; }
        public string VNDITNUM { get; set; }
        public decimal QTYSHPPD { get; set; }
        public decimal QTYINVCD { get; set; }
        public string UOFM { get; set; }
        public string LOCNCODE { get; set; }
        public string CURNCYID { get; set; }
      //  [JsonProperty("UNITCOST")]
        public decimal UNITCOST { get; set; }
        public string Purchase_Site_Tax_Schedu { get; set; }
        public string Purchase_Item_Tax_Schedu { get; set; }
        public short Purchase_IV_Item_Taxable { get; set; }

        public static implicit operator taPopRcptLineInsert_ItemsTaPopRcptLineInsert(POPLine pOPLine)
        {
            return new taPopRcptLineInsert_ItemsTaPopRcptLineInsert
            {
                POPTYPE = pOPLine.POPTYPE,
                POPRCTNM = pOPLine.POPRCTNM,
                ITEMNMBR = pOPLine.ITEMNMBR,
                VENDORID = pOPLine.VENDORID,
                VNDITNUM = pOPLine.VNDITNUM,
                QTYSHPPD = pOPLine.QTYSHPPD,
                QTYINVCD = pOPLine.QTYINVCD,
                UOFM = pOPLine.UOFM,
                CURNCYID = pOPLine.CURNCYID,
                LOCNCODE = pOPLine.LOCNCODE,
                UNITCOST = pOPLine.UNITCOST,
                UNITCOSTSpecified = true,
                Purchase_Site_Tax_Schedu = pOPLine.Purchase_Site_Tax_Schedu,
                Purchase_Item_Tax_Schedu = pOPLine.Purchase_Item_Tax_Schedu,
                Purchase_IV_Item_Taxable = pOPLine.Purchase_IV_Item_Taxable,
                
                //TAXAMNT=4.2m
                //Purchase_IV_Item_Taxable =(short)ItemTaxOptions.Taxable
                // ,UNITCOSTSpecified = false
                // ,AUTOCOST =1,


            };
        }

    }
}
