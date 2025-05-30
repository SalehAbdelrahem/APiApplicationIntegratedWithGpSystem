using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class ReceivableTransaction
    {
        public short RMDTYPAL { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public string DOCUMENTDATE { get; set; }

        public string BACHNUMBER { get; set; }
        public string CUSOMERNUMBRER { get; set; }
        public decimal DOCUMENTAMOUNT { get; set; }
        public decimal SALESAMOUNT { get; set; }

        public string CURNCYID { get; set; }
        public string TAXSCHID { get; set; }
        public decimal TRADEDISCOUNTAMOUNT { get; set; }
        public decimal FREIGHTAMOUNT { get; set; }
        public decimal MISCELLANEOUSAMOUNT { get; set; }
        public decimal TAXAMOUNT { get; set; }
        public static implicit operator taRMTransaction(ReceivableTransaction receivableTransaction) =>
            new taRMTransaction
            {
                RMDTYPAL = receivableTransaction.RMDTYPAL, 
                DOCNUMBR = receivableTransaction.DOCUMENTNUMBER,
                DOCDATE = receivableTransaction.DOCUMENTDATE,
                BACHNUMB = receivableTransaction.BACHNUMBER,
                CUSTNMBR = receivableTransaction.CUSOMERNUMBRER,
                DOCAMNT = receivableTransaction.DOCUMENTAMOUNT,
                SLSAMNT = receivableTransaction.SALESAMOUNT,
               // TAXAMNT = receivableTransaction.TAXAMOUNT,
                TAXSCHID = receivableTransaction.TAXSCHID,
                CURNCYID = receivableTransaction.CURNCYID
            };
    }
}
