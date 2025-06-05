using IntegratorWithGp.Core.Models.ItemVendors;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Purchasing.TransactionEntries
{
    public class PMTransaction
    {
       
        public string BATCHNUMBER { get; set; }
        public string VOUCHERNUMBER { get; set; }
        public string VENDORID { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public short DOCUMENTTYPE { get; set; } //Document type: 1=Invoice, 2=Finance Charge, 3=Miscellaneous Charge , 4=Return, 5=Credit Memo
        public decimal DOCUMENTAMOUNT { get; set; }
        public string DOCUMENTDATE { get; set; }
        public string CURNCYID { get; set; }
        public string TAXSCHID { get; set; }
        public string TRANSACTIONDESCRIPTION{ get; set; }
        public decimal PURCHASESAMOUNT { get; set; }
        public decimal TAXAMOUNT { get; set; }
        public decimal CHARGEAMOUNT { get; set; }

        

        public static implicit operator taPMTransactionInsert(PMTransaction payableTransaction) =>
       new taPMTransactionInsert
       {

           BACHNUMB= payableTransaction.BATCHNUMBER,
           VENDORID = payableTransaction.VENDORID,
           VCHNUMWK=payableTransaction.VOUCHERNUMBER,
           DOCTYPE= payableTransaction.DOCUMENTTYPE,
           DOCNUMBR = payableTransaction.DOCUMENTNUMBER,
           DOCDATE  =payableTransaction.DOCUMENTDATE,
           CURNCYID = payableTransaction.CURNCYID,
           TAXSCHID = payableTransaction.TAXSCHID,
           PRCHAMNT = payableTransaction.PURCHASESAMOUNT,
           DOCAMNT = payableTransaction.DOCUMENTAMOUNT,
           TAXAMNT = payableTransaction.TAXAMOUNT,
           CHRGAMNT = payableTransaction.CHARGEAMOUNT,
           TRXDSCRN=payableTransaction.TRANSACTIONDESCRIPTION,
         
       };
    }
}
