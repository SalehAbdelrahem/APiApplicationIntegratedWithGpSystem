using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.Purchasing.TransactionEntries
{
    public class PMDistribution
    {
        public short DOCUMENTTYPE { get; set; }
        public string VOUCHERNUMBER { get; set; }
        public string VENDORID { get; set; }
        public short DISTRIBUTIONTYPE { get; set; }
        public string ACCOUNTNUMBERSTRING { get; set; }
        public decimal CREDITAMOUNT { get; set; }
        public static implicit operator taPMDistribution_ItemsTaPMDistribution(PMDistribution pMDistribution)
        {
            return new taPMDistribution_ItemsTaPMDistribution
            {
                DOCTYPE = pMDistribution.DOCUMENTTYPE,
                VCHRNMBR = pMDistribution.VOUCHERNUMBER,
                VENDORID = pMDistribution.VENDORID,
                DISTTYPE=pMDistribution.DISTRIBUTIONTYPE,
                ACTNUMST = pMDistribution.ACCOUNTNUMBERSTRING,
                CRDTAMNT= pMDistribution.CREDITAMOUNT
            };
        }
    }
}
