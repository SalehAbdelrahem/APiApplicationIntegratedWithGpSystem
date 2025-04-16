using System.Collections.Generic;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class SalesTransaction
    {
        public SOPHeader SOPHeader { get; set; }
        public SOPUserDefined SOPUserDefined { get; set; }
        public List<SOPLine> SOPLines { get; set; }
    }
}
