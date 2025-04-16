using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Vendors;

namespace IntegratorWithGp.Services.Iservices.IVendorService
{
    public interface IVendorService
    {
        GeneralResponceApi CreateUpdate(Vendor vendor);
    }
}
