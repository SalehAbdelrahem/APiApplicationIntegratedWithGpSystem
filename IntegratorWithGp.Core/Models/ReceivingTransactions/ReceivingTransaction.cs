using IntegratorWithGp.Core.Models.SalesTransactions;
using System.Collections.Generic;

namespace IntegratorWithGp.Core.Models.ReceivingTransactions
{
    public class ReceivingTransaction
    {
        public POPHeader POPHeader { get; set; }
        public POPUserDefined POPUserDefined { get; set; }
        public List<POPLine> POPLines { get; set; }
    }
}
