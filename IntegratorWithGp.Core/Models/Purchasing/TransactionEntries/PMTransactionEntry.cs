using System.Collections.Generic;

namespace IntegratorWithGp.Core.Models.Purchasing.TransactionEntries
{
    public class PMTransactionEntry
    {
        public PMTransaction PMTransactionInsert { get; set; }
        public List<PMTransactionTax> PMTransactionTaxes { get; set; }
        public List<PMDistribution> PMDistributions { get; set; }
    }
}
