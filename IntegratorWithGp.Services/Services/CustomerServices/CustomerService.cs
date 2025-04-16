using System;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Customers;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.Iservices.ICustomerServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public GeneralResponceApi CreateUpdate(Customer customer)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType updateCreateCustomer = new eConnectType();
                    updateCreateCustomer.RMCustomerMasterType = new RMCustomerMasterType[]
                    {
                        new RMCustomerMasterType()
                        {
                            taUpdateCreateCustomerRcd=customer
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(updateCreateCustomer);
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
            //catch (eConnectException ex)
            //{
            //    response.IsSuccess = false;
            //    response.Message = ex.Message;

            //}
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
