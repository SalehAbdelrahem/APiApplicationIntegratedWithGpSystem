using System;
using System.Collections.Generic;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Extentions.IVItemVendors;
using IntegratorWithGp.Core.Models.ItemVendors;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.IItemVendorServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.ItemVendorServices
{
    public class ItemVendorService : IItemVendorService
    {
        public GeneralResponceApi CreateUpdateItemVendors(List<ItemVendor> itemVendors)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType IVItemTransaction = new eConnectType();
                    IVItemTransaction.IVItemMasterType = new IVItemMasterType[]
                    {
                        new IVItemMasterType ()
                        {
                            taCreateItemVendors_Items=itemVendors.ToINVtaCreateItemVendors_ItemsArray()
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(IVItemTransaction);
                    var isUpdated = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (isUpdated)
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
                if (ex.Message.Contains("Error Number = 3250"))
                    response.Message = "The Item Number(ITEMNMBR) passed does not currently exist in Item Master table - IV00101";
                else if (ex.Message.Contains("Error Number = 3252"))
                    response.Message = "The Vendor ID (VENDORID) passed does not currently exist in Vendor Master table - PM00200";
                else
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
