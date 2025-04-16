using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class SOPLine
    {
        public short SOPTYPE { get; set; }
        public string DOCID { get; set; }
        public string SOPNUMBE { get; set; }
        public string DOCDATE { get; set; }
        public string CUSTNMBR { get; set; }
        public string ITEMNMBR { get; set; }

        public string CURNCYID { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal UNITPRCE { get; set; }
        public string UOFM { get; set; }
        public string TAXSCHID { get; set; }
        public string ITMTSHID { get; set; }
        public short IVITMTXB { get; set; }
        // public int DEFEXTPRICE { get; set; }
        public short UpdateIfExists { get; set; }
        public static implicit operator taSopLineIvcInsert_ItemsTaSopLineIvcInsert(SOPLine sOPLine)
        {
            return new taSopLineIvcInsert_ItemsTaSopLineIvcInsert
            {
                SOPTYPE = sOPLine.SOPTYPE,
                DOCID = sOPLine.DOCID,
                SOPNUMBE = sOPLine.SOPNUMBE,
                DOCDATE = sOPLine.DOCDATE,
                CUSTNMBR = sOPLine.CUSTNMBR,
                ITEMNMBR = sOPLine.ITEMNMBR,
                CURNCYID = sOPLine.CURNCYID,
                QUANTITY = sOPLine.QUANTITY,
                UNITPRCE = sOPLine.UNITPRCE,
                UOFM = sOPLine.UOFM,
                TAXSCHID = sOPLine.TAXSCHID,
                ITMTSHID = sOPLine.ITMTSHID,
                IVITMTXB = sOPLine.IVITMTXB,
                DEFEXTPRICE = 1,
                UpdateIfExists = sOPLine.UpdateIfExists
            };
        }

    }
}
