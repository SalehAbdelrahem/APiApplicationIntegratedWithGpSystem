using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IntegratorWithGp.Core.Extentions.Purchasings
{
    public static class PurchasingExtentionMethods
    {
        public static taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert[] ToPMTransactionsTaxesArray(this IEnumerable<PMTransactionTax> pMTransactionTaxes)
        {
            if (pMTransactionTaxes == null) throw new ArgumentNullException(nameof(pMTransactionTaxes));

            return pMTransactionTaxes.Select(pMTransactionTaxe => (taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert)pMTransactionTaxe).ToArray();
        } 
        public static taPMDistribution_ItemsTaPMDistribution[] ToPMDistributionsArray(this IEnumerable<PMDistribution> pMDistributions)
        {
            if (pMDistributions == null) throw new ArgumentNullException(nameof(pMDistributions));

            return pMDistributions.Select(pMDistribution => (taPMDistribution_ItemsTaPMDistribution)pMDistribution).ToArray();
        }
    }
}
