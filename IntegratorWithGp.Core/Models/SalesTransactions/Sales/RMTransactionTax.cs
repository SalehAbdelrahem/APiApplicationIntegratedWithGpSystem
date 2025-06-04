using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions.Sales
{
    public class RMTransactionTax
    {
        public string CUSTOMERID { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public short DOCUMENTTYPE { get; set; }
        public string BATCHNUMBER { get; set; }
        public string TAXDETAILID { get; set; }
        public decimal TAXAMOUNT { get; set; }
        public decimal SALESTAXAMOUNT { get; set; }
        public decimal TAXDETAILTOTALSALES { get; set; }
        public string ACCOUNTNUMBERSTRING { get; set; }

        public static implicit operator taRMTransactionTaxInsert_ItemsTaRMTransactionTaxInsert(RMTransactionTax rMTransactionTax)
        {
            return new taRMTransactionTaxInsert_ItemsTaRMTransactionTaxInsert
            {
                CUSTNMBR = rMTransactionTax.CUSTOMERID,
                DOCNUMBR = rMTransactionTax.DOCUMENTNUMBER,
                RMDTYPAL = rMTransactionTax.DOCUMENTTYPE,
                BACHNUMB = rMTransactionTax.BATCHNUMBER,
                TAXDTLID = rMTransactionTax.TAXDETAILID,
                TAXAMNT = rMTransactionTax.TAXAMOUNT,
                STAXAMNT = rMTransactionTax.SALESTAXAMOUNT,
                TAXDTSLS = rMTransactionTax.TAXDETAILTOTALSALES,
                ACTNUMST = rMTransactionTax.ACCOUNTNUMBERSTRING
            };
        }
    }
}
