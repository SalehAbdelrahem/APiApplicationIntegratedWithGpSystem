using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Purchasing.TransactionEntries
{
    public class PMTransactionTax
    {
        public string VENDORID { get; set; }
        public string VOUCHERNUMBER { get; set; }
        public short DOCUMENTTYPE { get; set; }
        public string BATCHNUMBER { get; set; }
        public string TAXDETAILID { get; set; }
        public decimal TAXAMOUNT { get; set; }
        public string ACCOUNTNUMBERSTRING { get; set; }



        public static implicit operator taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert(PMTransactionTax pMTransactionTax)
        {
            return new taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert
            {
                VENDORID = pMTransactionTax.VENDORID,
                VCHRNMBR = pMTransactionTax.VOUCHERNUMBER,
                DOCTYPE = pMTransactionTax.DOCUMENTTYPE,
                BACHNUMB = pMTransactionTax.BATCHNUMBER,
                TAXDTLID = pMTransactionTax.TAXDETAILID,
                TAXAMNT = pMTransactionTax.TAXAMOUNT,
                ACTNUMST = pMTransactionTax.ACCOUNTNUMBERSTRING

            };
        }
    }
}
