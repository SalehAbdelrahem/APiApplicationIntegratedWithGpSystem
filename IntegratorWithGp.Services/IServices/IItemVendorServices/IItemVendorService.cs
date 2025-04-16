using System.Collections.Generic;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.ItemVendors;

namespace IntegratorWithGp.Services.IServices.IItemVendorServices
{
    public interface IItemVendorService
    {
        GeneralResponceApi CreateUpdateItemVendors(List<ItemVendor> itemVendors);
    }
}
