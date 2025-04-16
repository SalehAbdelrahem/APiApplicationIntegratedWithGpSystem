using System;
using System.Collections.Generic;
using System.Linq;
using IntegratorWithGp.Core.Models.ReceivingTransactions;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Extentions.ReceivingTransactions
{
    public static class ReceivingsTransactionExtentionMethods
    {
        public static taPopRcptLineInsert_ItemsTaPopRcptLineInsert[] ToTaPopRECPLineInsertArray(this IEnumerable<POPLine> popLines)
        {
            if (popLines == null) throw new ArgumentNullException(nameof(popLines));

            return popLines.Select(popLine => (taPopRcptLineInsert_ItemsTaPopRcptLineInsert)popLine).ToArray();
        }
    }
}
