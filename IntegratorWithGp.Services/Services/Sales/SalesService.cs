using System;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Enums;
using IntegratorWithGp.Core.Extentions.Sales;
using IntegratorWithGp.Core.Models.SalesTransactions;
using IntegratorWithGp.Core.Models.SalesTransactions.Sales;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.ISales;
using IntegratorWithGp.Services.Services.PurchasingServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.Sales
{
    public class SalesService : ISalesService
    {
        public GeneralResponceApi InsertReceivableTransaction(RMTransactionEntry rMTransactionEntry)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType ReceivableTransactionType = new eConnectType();
                    ReceivableTransactionType.RMTransactionType = new RMTransactionType[]
                    {
                        new RMTransactionType()
                        {
                            taRMTransaction= rMTransactionEntry.RMTransactionInsert,
                            taRMTransactionTaxInsert_Items=rMTransactionEntry.RMTransactionTaxes.ToRMTransactionsTaxesArray(),
                            taRMDistribution_Items=rMTransactionEntry.RMDistributions.ToRMDistributionsArray()

                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(ReceivableTransactionType);
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
                if (ex.Message.Contains("Error Number = 190"))
                {
                    response.Message = "Error Description = Document number (DOCNUMBR) already exists in either RM00401, RM10301, RM20101 or RM30101";
                } 
                else if (ex.Message.Contains("Error Number = 483"))
                {
                    response.Message = "Error Description = The Currency ID does not exist in MC40200";
                }
                else if (ex.Message.Contains("Error Number = 221"))
                {
                    response.Message = "Error Description = The Customer Number (CUSTNMBR) does not exist in the Customer Master Table - RM00101";
                }
                else if (ex.Message.Contains("Error Number = 621"))
                {
                    response.Message = "Error Description = Document Amount is incorrect - (DOCAMNT <> SLSAMNT - TRDISAMT + FRTAMNT + MISCAMNT + TAXAMNT)";
                }
                else if (ex.Message.Contains("Error Number = 7023"))
                {
                    response.Message = "Error Description = The Tax Schedule ID entered (TAXSCHID) does not exist in the Sales Tax master table - TX00101";
                }
                else if (ex.Message.Contains("Error Number = 716"))
                {
                    response.Message = "Error Description = Account does not exist for Account Number String (ACTNUMST) passed";
                } 
                else if (ex.Message.Contains("Error Number = 712"))
                {
                    response.Message = "Error Description = Tax amount (TAXAMNT) does not equal tax details in RM10601";
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
        public string test()
        {
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectOut CashReciet = new eConnectOut()
                    {
                        OUTPUTTYPE=2,
                        //FORLIST = 1,
                        INDEX1FROM = "PYMNT000000000002",
                        INDEX1TO = "PYMNT000000000002",
                        //DOCTYPE = DOCTYPE.Cash_Receipt.ToString(),
                        DOCTYPE = "Cash_Receipt"
                       
                    };
                    eConnectType e = new eConnectType();
                    e.RQeConnectOutType = new RQeConnectOutType[]
                    {
                        new RQeConnectOutType()
                        {
                            eConnectOut=CashReciet,
                        }
                    };
           
                    string xml = GeneralOperationObject.SerializeObject(e);
                   var result= eConnect.GetEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    return result;
                }
            }
            catch (eConnectException ex)
            {
               return ex.Message;

            }
            catch (Exception ex)
            {
               // response.IsSuccess = false;
               // response.Message = ex.Message;
               return ex.Message;
            }

        }

    }
}
