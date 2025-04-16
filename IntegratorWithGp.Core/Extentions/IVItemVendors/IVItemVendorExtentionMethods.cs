using System;
using System.Collections.Generic;
using System.Linq;
using IntegratorWithGp.Core.Models.ItemVendors;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Extentions.IVItemVendors
{
    public static class IVItemVendorExtentionMethods
    {
        public static taCreateItemVendors_ItemsTaCreateItemVendors[] ToINVtaCreateItemVendors_ItemsArray(this IEnumerable<ItemVendor> itemVendors)
        {
            if (itemVendors == null) throw new ArgumentNullException(nameof(itemVendors));

            return itemVendors.Select(itemVendor => (taCreateItemVendors_ItemsTaCreateItemVendors)itemVendor).ToArray();
        }
    }
}
