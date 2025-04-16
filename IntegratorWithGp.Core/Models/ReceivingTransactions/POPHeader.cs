using System;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.ReceivingTransactions
{
    public class POPHeader
    {
        public short POPTYPE { get; set; }
        public string POPRCTNM { get; set; }
        public string receiptdate { get; set; }
        public string BACHNUMB { get; set; }
        public string VENDORID { get; set; }
        public string CURNCYID { get; set; }
        public string VNDDOCNM { get; set; }
       
        public static implicit operator taPopRcptHdrInsert(POPHeader pOPHeader)
        {
            return new taPopRcptHdrInsert
            {
                POPTYPE = pOPHeader.POPTYPE,
                POPRCTNM = pOPHeader.POPRCTNM,
                receiptdate = pOPHeader.receiptdate,
                //receiptdate = DateTime.Now.ToString("dd/MM/yyyy"),
                BACHNUMB = pOPHeader.BACHNUMB??$"IST-{DateTime.Now.Date.ToString("dd/MM/yyyy")}",
                VENDORID = pOPHeader.VENDORID,
                CURNCYID = pOPHeader.CURNCYID,
                VNDDOCNM = pOPHeader.VNDDOCNM
                // ,TAXAMNT=4.2m
                // ,TAXSCHID="VAT"
                //, Purchase_Freight_Taxable=1
                //,Purchase_Misc_Taxable=1
                //,USINGHEADERLEVELTAXES = 1

                // , Tax_Date = DateTime.Now.ToString("dd/MM/yyyy")


            };
        }
    }
}
