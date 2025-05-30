using System;
using System.Security.Cryptography;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using IntegratorWithGp.Core.Models.Vendors;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.IPurchasingServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.PurchasingServices
{
    public class PurchasingService : IPurchasingService
    {
        public GeneralResponceApi InsertPayablesTransaction(PayableTransaction PayableTransaction)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType PayablesTransactionType = new eConnectType();
                    PayablesTransactionType.PMTransactionType = new PMTransactionType[]
                    {
                        new PMTransactionType()
                        {
                            taPMTransactionInsert=PayableTransaction,
                            //taPMTransactionTaxInsert_Items=new taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert[]
                            //{
                            //    new taPMTransactionTaxInsert_ItemsTaPMTransactionTaxInsert
                            //    {
                            //        VENDORID=PayableTransaction.VENDORID,
                            //        VCHRNMBR=PayableTransaction.VOUCHERNUMBER,
                            //        DOCTYPE=PayableTransaction.DOCUMENTTYPE,
                            //        BACHNUMB=PayableTransaction.BACHNUMBER,
                            //        TAXDTLID="W1",
                            //        TAXAMNT=-5
                            //    }
                            //}
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(PayablesTransactionType);
                    var isDone = eConnect.CreateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (!string.IsNullOrEmpty(isDone))
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
                if (ex.Message.Contains("Error Number = 305"))
                {
                    response.Message = "Error Description = Document Number (DOCNUMBR) already exists in the PM00400, PM10000, PM20000, PM30200, POP10300 or the MC020103 Table (has been Ceated Before)";
                } 
                else if (ex.Message.Contains("Error Number = 309"))
                {
                    response.Message = "Error Description = Tax Schedule ID(TAXSCHID) does not exist in the Sales/ Purchase Tax Schedule Master Table -TX00102";
                }
                else if (ex.Message.Contains("Error Number = 372"))
                {
                    response.Message = "Error Description = The Vendor ID (VENDORID) does not exist in the Vendor Master Table - PM00200";
                }                
                else if (ex.Message.Contains("Error Number = 11479"))
                {
                    response.Message = "Error Description = No Checkbook ID has been passed for the new batch number - pass a batch checkbook id (BatchCHEKBKID) or add a default checkbook in Payables Setup";
                }  else if (ex.Message.Contains("Error Number = 308"))
                {
                    response.Message = " Error Description = Document Amount is incorrect - DOCAMNT <> MSCCHAMT + PRCHAMNT + TAXAMNT + FRTAMNT - TRDISAMT";
                }
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
