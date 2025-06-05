using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Extentions.Purchasings;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.IPurchasingServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System;

namespace IntegratorWithGp.Services.Services.PurchasingServices
{
    public class PurchasingService : IPurchasingService
    {
        public GeneralResponceApi InsertPayablesTransaction(PMTransactionEntry PMTransactionEntry)
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

                            taPMTransactionInsert=PMTransactionEntry.PMTransactionInsert,
                            taPMTransactionTaxInsert_Items=PMTransactionEntry.PMTransactionTaxes.ToPMTransactionsTaxesArray(),
                            taPMDistribution_Items=PMTransactionEntry.PMDistributions.ToPMDistributionsArray()

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
                }
                else if (ex.Message.Contains("Error Number = 308"))
                {
                    response.Message = "Error Description = Document Amount is incorrect - DOCAMNT <> MSCCHAMT + PRCHAMNT + TAXAMNT + FRTAMNT - TRDISAMT";
                } 
                else if (ex.Message.Contains("Error Number = 447"))
                {
                    response.Message = "Error Description = Account does not exist for Account Number String given";
                } 
                else if (ex.Message.Contains("Error Number = 768"))
                {
                    response.Message = "Error Description = Account does not exist for Account Index";
                } 
                else if (ex.Message.Contains("Error Number = 313"))
                {
                    response.Message = "Error Description = Tax table detail does not equal the tax amount";
                } 
                else if (ex.Message.Contains("Error Number = 399"))
                {
                    response.Message = "Error Description = Charge Amount is incorrect - CHRGAMNT <> DOCAMNT - CASHAMNT - CHEKAMNT - CRCRDAMT - DISTKNAM";
                }  
                else if (ex.Message.Contains("Error Number = 698"))
                {
                    response.Message = "Error Description = Tax record already exists in the PM Tax Work Table - PM10500";
                } else if (ex.Message.Contains("Error Number = 7148"))
                {
                    response.Message = "Error Description = Duplicate Tax Node ID in the RM10601 table";
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
