using System.Collections.Generic;

namespace IntegratorWithGp.Core.Models.SalesTransactions.Sales
{
    public class RMTransactionEntry
    {
        public RMTransaction RMTransactionInsert { get; set; }
        public List<RMTransactionTax> RMTransactionTaxes { get; set; }
        public List<RMDistribution> RMDistributions { get; set; }
    }
}
