using System;
using System.Collections.Generic;
using System.Linq;
using IntegratorWithGp.Core.Models.SalesTransactions;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Extentions.SalesTransactions
{
    public static class SalesTransactionExtentionMethods
    {
        public static taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] ToTaSopLineIvcInsertArray(this IEnumerable<SOPLine> sopLines)
        {
            if (sopLines == null) throw new ArgumentNullException(nameof(sopLines));

            return sopLines.Select(sopLine => (taSopLineIvcInsert_ItemsTaSopLineIvcInsert)sopLine).ToArray();
        }

    }
}
