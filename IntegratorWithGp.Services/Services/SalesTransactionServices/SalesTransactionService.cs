using System;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Extentions.SalesTransactions;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using IntegratorWithGp.Core.Models.SalesTransactions;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.ISalesTransactionServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.SalesTransactionServices
{
    public class SalesTransactionService : ISalesTransactionService
    {
        public GeneralResponceApi CreateSOP(SalesTransaction salesTransaction)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {

                    eConnectType CreateSOPTransaction = new eConnectType();

                    CreateSOPTransaction.SOPTransactionType = new SOPTransactionType[]
                    {
                        new SOPTransactionType
                        {
                            taSopHdrIvcInsert=salesTransaction.SOPHeader,
                            taSopLineIvcInsert_Items= salesTransaction.SOPLines.ToTaSopLineIvcInsertArray(),
                            taSopUserDefined=salesTransaction.SOPUserDefined,
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(CreateSOPTransaction);
                    var result = eConnect.CreateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (!string.IsNullOrEmpty(result))
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
                if (ex.Message.Contains("Error Number = 9539"))
                {
                    response.Message = "The Salesperson is set to inactive in the Salesperson Master Table - RM00301.";
                }
                else if (ex.Message.Contains("Error Number = 2079") || ex.Message.Contains("Error Number = 2022"))
                {
                    response.Message = "Document is currently being edited by another user.";
                }
                else if (ex.Message.Contains("Error Number = 9370"))
                {
                    response.Message = "You are passing a Currency ID in the header and did not pass the same one to the line.";
                }
                else if (ex.Message.Contains("Error Number = 3551"))
                {
                    response.Message = "Serial Number does not exist in Item Serial Number Master -IV00200.";
                }
                else if (ex.Message.Contains("Error Number = 2902"))
                {
                    response.Message = "Item Number does not match Item Number on the existing line.";
                }
                else if (ex.Message.Contains("Error Number = 1526"))
                {
                    response.Message = "The Serial Number has already been sold - please choose another Serial Number.";
                }
                else if (ex.Message.Contains("Error Number = 2905"))
                {
                    response.Message = "Qty fulfilled cannot exceed qty allocated. Node Identifier Parameters: taSopSerial.";
                }
                else if (ex.Message.Contains("Error Number = 722"))
                {
                    response.Message = "Unit Price calculation does not match out to Extended price.";
                }
                else if (ex.Message.Contains("Error Number = 67"))
                {
                    response.Message = "taSopHdrIvcInsert Subtotal does not match the line item totals .";
                }
                else if (ex.Message.Contains("Error Number = 235"))
                {
                    response.Message = "Document amount does not equal(Subtotal+Freight + Misc + TaxAmt + FreightTax + MiscTax - TradeDisc).";
                }
                else if (ex.Message.Contains("Error Number = 2221"))
                {
                    response.Message = "Duplicate document number";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public GeneralResponceApi UpdateSOPLine(SOPLine sOPLine)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {

                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType UpdateSOPLineType = new eConnectType();
                    UpdateSOPLineType.SOPTransactionType = new SOPTransactionType[]
                    {
                        new SOPTransactionType
                        {
                            taSopLineIvcInsert_Items= new taSopLineIvcInsert_ItemsTaSopLineIvcInsert[]{ sOPLine }
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(UpdateSOPLineType);
                    var result = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (result)
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
                //if (ex.Message.Contains("Error Number = 9539"))

                //    response.Message = "The Salesperson is set to inactive in the Salesperson Master Table - RM00301.";

                //else if (ex.Message.Contains("Error Number = 2079") || ex.Message.Contains("Error Number = 2022"))

                //    response.Message = "Document is currently being edited by another user.";

                //else if (ex.Message.Contains("Error Number = 9370"))

                //    response.Message = "You are passing a Currency ID in the header and did not pass the same one to the line.";

                //else if (ex.Message.Contains("Error Number = 3551"))

                //    response.Message = "Serial Number does not exist in Item Serial Number Master -IV00200.";

                //else if (ex.Message.Contains("Error Number = 2902"))

                //    response.Message = "Item Number does not match Item Number on the existing line.";

                //else if (ex.Message.Contains("Error Number = 1526"))

                //    response.Message = "The Serial Number has already been sold - please choose another Serial Number.";

                //else if (ex.Message.Contains("Error Number = 2905"))

                //    response.Message = "Qty fulfilled cannot exceed qty allocated. Node Identifier Parameters: taSopSerial.";

                //else if (ex.Message.Contains("Error Number = 722"))

                //    response.Message = "Unit Price calculation does not match out to Extended price.";

                //else if (ex.Message.Contains("Error Number = 67"))

                //    response.Message = "taSopHdrIvcInsert Subtotal does not match the line item totals .";

                //else if (ex.Message.Contains("Error Number = 235"))

                //    response.Message = "Document amount does not equal(Subtotal+Freight + Misc + TaxAmt + FreightTax + MiscTax - TradeDisc).";

                //else if (ex.Message.Contains("Error Number = 2221"))

                //    response.Message = "Duplicate document number";

                //else
                //    response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public GeneralResponceApi DeleteSOPLine(DeleteSOPLine sOPLine)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {

                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType DeleteSOPLineType = new eConnectType();
                    DeleteSOPLineType.SOPDeleteLineType = new SOPDeleteLineType[]
                    {
                        new SOPDeleteLineType
                        {
                            taSopLineDelete= sOPLine
                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(DeleteSOPLineType);
                    var result = eConnect.DeleteTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (result)
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
                //if (ex.Message.Contains("Error Number = 9539"))

                //    response.Message = "The Salesperson is set to inactive in the Salesperson Master Table - RM00301.";

                //else if (ex.Message.Contains("Error Number = 2079") || ex.Message.Contains("Error Number = 2022"))

                //    response.Message = "Document is currently being edited by another user.";

                //else if (ex.Message.Contains("Error Number = 9370"))

                //    response.Message = "You are passing a Currency ID in the header and did not pass the same one to the line.";

                //else if (ex.Message.Contains("Error Number = 3551"))

                //    response.Message = "Serial Number does not exist in Item Serial Number Master -IV00200.";

                //else if (ex.Message.Contains("Error Number = 2902"))

                //    response.Message = "Item Number does not match Item Number on the existing line.";

                //else if (ex.Message.Contains("Error Number = 1526"))

                //    response.Message = "The Serial Number has already been sold - please choose another Serial Number.";

                //else if (ex.Message.Contains("Error Number = 2905"))

                //    response.Message = "Qty fulfilled cannot exceed qty allocated. Node Identifier Parameters: taSopSerial.";

                //else if (ex.Message.Contains("Error Number = 722"))

                //    response.Message = "Unit Price calculation does not match out to Extended price.";

                //else if (ex.Message.Contains("Error Number = 67"))

                //    response.Message = "taSopHdrIvcInsert Subtotal does not match the line item totals .";

                //else if (ex.Message.Contains("Error Number = 235"))

                //    response.Message = "Document amount does not equal(Subtotal+Freight + Misc + TaxAmt + FreightTax + MiscTax - TradeDisc).";

                //else if (ex.Message.Contains("Error Number = 2221"))

                //    response.Message = "Duplicate document number";

                //else
                //    response.Message = ex.Message;
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
