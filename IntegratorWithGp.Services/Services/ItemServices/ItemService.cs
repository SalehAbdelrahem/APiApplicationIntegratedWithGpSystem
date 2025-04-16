using System;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Items;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.IItemServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.ItemServices
{
    public class ItemService : IItemService
    {
        public GeneralResponceApi CreateUpdate(Item item)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType updateCreateItem= new eConnectType();
                    updateCreateItem.IVItemMasterType = new IVItemMasterType[]
                    {
                        new IVItemMasterType()
                        {
                            taUpdateCreateItemRcd=item
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(updateCreateItem);
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
               response.Message= ex.Message;
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
