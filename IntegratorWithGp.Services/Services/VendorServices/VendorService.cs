using System;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Vendors;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.Iservices.IVendorService;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.VendorService
{
    public class VendorService : IVendorService
    {
        public GeneralResponceApi CreateUpdate(Vendor vendor)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {

                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType updateCreateVendor = new eConnectType();
                    updateCreateVendor.PMVendorMasterType = new PMVendorMasterType[]
                    {
                        new PMVendorMasterType()
                        {
                            taUpdateCreateVendorRcd=vendor
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(updateCreateVendor);
                    var isDone = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (isDone)
                    {
                        response.IsSuccess = true;
                        response.Message = "this transaction hase been Successfuly";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "this transaction hase been failed";
                    }
                }
            }
            catch (eConnectException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
