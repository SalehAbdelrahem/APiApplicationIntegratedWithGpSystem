using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions.Sales
{
    public class RMTransaction
    {
        public short RMDTYPAL { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public string DOCUMENTDATE { get; set; }

        public string BATCHNUMBER { get; set; }
        public string CUSOMERNUMBRER { get; set; }
        public decimal DOCUMENTAMOUNT { get; set; }
        public decimal SALESAMOUNT { get; set; }

        public string CURNCYID { get; set; }
        public string TAXSCHID { get; set; }
        //public decimal TRADEDISCOUNTAMOUNT { get; set; }
        //public decimal FREIGHTAMOUNT { get; set; }
        //public decimal MISCELLANEOUSAMOUNT { get; set; }
        public decimal TAXAMOUNT { get; set; }
        public string  DOCUMENTDESCRIPTION  { get; set; }
        public static implicit operator taRMTransaction(RMTransaction receivableTransaction) =>
            new taRMTransaction
            {
                RMDTYPAL = receivableTransaction.RMDTYPAL, 
                DOCNUMBR = receivableTransaction.DOCUMENTNUMBER,
                DOCDATE = receivableTransaction.DOCUMENTDATE,
                BACHNUMB = receivableTransaction.BATCHNUMBER,
                CUSTNMBR = receivableTransaction.CUSOMERNUMBRER,
                DOCAMNT = receivableTransaction.DOCUMENTAMOUNT,
                SLSAMNT = receivableTransaction.SALESAMOUNT,
                TAXSCHID = receivableTransaction.TAXSCHID,
                CURNCYID = receivableTransaction.CURNCYID,
                DOCDESCR=receivableTransaction.DOCUMENTDESCRIPTION
               ,TAXAMNT = receivableTransaction.TAXAMOUNT
            };
    }
}
