using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions.Sales
{
    public class RMDistribution
    {
        public short RMDTYPAL { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public string VENDORID { get; set; }
        public short DISTRIBUTIONTYPE { get; set; }
        public string ACCOUNTNUMBERSTRING { get; set; }
        public decimal DEBITAMOUNT { get; set; }
        public static implicit operator taRMDistribution_ItemsTaRMDistribution(RMDistribution rMDistribution)
        {
            return new taRMDistribution_ItemsTaRMDistribution
            {
                RMDTYPAL = rMDistribution.RMDTYPAL,
                DOCNUMBR = rMDistribution.DOCUMENTNUMBER,
                CUSTNMBR = rMDistribution.VENDORID,
                DISTTYPE = rMDistribution.DISTRIBUTIONTYPE,
                ACTNUMST = rMDistribution.ACCOUNTNUMBERSTRING,
                DEBITAMT = rMDistribution.DEBITAMOUNT
            };
        }
    }
}
