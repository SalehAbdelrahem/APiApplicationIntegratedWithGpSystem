using IntegratorWithGp.Core.Models.SalesTransactions.Sales;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IntegratorWithGp.Core.Extentions.Sales
{
    public static class SalesExtentionMethods
    {
        public static taRMTransactionTaxInsert_ItemsTaRMTransactionTaxInsert[] ToRMTransactionsTaxesArray(this IEnumerable<RMTransactionTax> rMTransactionTaxes)
        {
            if (rMTransactionTaxes == null) throw new ArgumentNullException(nameof(rMTransactionTaxes));

            return rMTransactionTaxes.Select(rMTransactionTaxe => (taRMTransactionTaxInsert_ItemsTaRMTransactionTaxInsert)rMTransactionTaxe).ToArray();
        }
        public static taRMDistribution_ItemsTaRMDistribution[] ToRMDistributionsArray(this IEnumerable<RMDistribution> rMDistributions)
        {
            if (rMDistributions == null) throw new ArgumentNullException(nameof(rMDistributions));

            return rMDistributions.Select(rMDistribution => (taRMDistribution_ItemsTaRMDistribution)rMDistribution).ToArray();
        }
    }
}
