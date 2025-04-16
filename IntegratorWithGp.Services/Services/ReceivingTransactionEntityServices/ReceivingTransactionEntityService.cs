using System;
using System.Linq;
using IntegratorWithGp.Core;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Extentions.ReceivingTransactions;
using IntegratorWithGp.Core.Models.ItemVendors;
using IntegratorWithGp.Core.Models.ReceivingTransactions;
using IntegratorWithGp.Core.StaticClasses;
using IntegratorWithGp.Services.IServices.IItemVendorServices;
using IntegratorWithGp.Services.IServices.IReceivingTransactionEntityServices;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.Services.ReceivingTransactionEntityServices
{
    public class ReceivingTransactionEntityService : IReceivingTransactionEntityService
    {
        private readonly IItemVendorService _itemVendorService;

        public ReceivingTransactionEntityService(IItemVendorService itemVendorService)
        {
            _itemVendorService = itemVendorService;
        }

        public GeneralResponceApi CreatePOP(ReceivingTransaction receivingTransaction)
        {
            GeneralResponceApi response = new GeneralResponceApi();
            try
            {
                using (eConnectMethods eConnect = new eConnectMethods())
                {
                    eConnectType CreatePOPTransaction = new eConnectType();
                    CreatePOPTransaction.POPReceivingsType = new POPReceivingsType[]
                    {
                        new POPReceivingsType
                        {
                            taPopRcptHdrInsert=receivingTransaction.POPHeader,
                            taPopRcptLineInsert_Items= receivingTransaction.POPLines.ToTaPopRECPLineInsertArray(),
                            taPopRctUserDefined=receivingTransaction.POPUserDefined,
                            

                        }
                    };
                    string xml = GeneralOperationObject.SerializeObject(CreatePOPTransaction);
                    var result = eConnect.CreateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
                    if (!string.IsNullOrEmpty(result))
                    //if (isUpdated)
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

                if (ex.Message.Contains("Error Number = 1779"))
                {
                    var result = AssignVendors(receivingTransaction);
                    if (result.IsSuccess)
                    {
                        return CreatePOP(receivingTransaction);
                    }
                    response.Message = $"Ann Error When Assign vendor to items , Exceptione Error = {response.Message}";

                    // response.Message = "Item Number/Vendor Item number is not assigned to the Vendor";
                }

                else if (ex.Message.Contains("Error Number = 6357"))
                    response.Message = "Vendor Document numbers(VNDDOCNM) for Shipment / Invoices(POPTYPE = 3) are required";
                else if (ex.Message.Contains("Error Number = 4601"))
                    response.Message = "LOCNCODE is required when receiving with out a purchase order ";
                else if (ex.Message.Contains("Error Number = 4604"))
                    response.Message = "Item number/location code does not exist in inventory";
                else if (ex.Message.Contains("Error Number = 8052"))
                    response.Message = "Unit Cost cannot be less then 0 or null, unless AUTOCOST = 1";
                else if (ex.Message.Contains("Error Number = 8053"))
                    response.Message = "Input variable contains a duplicate document (POPRCTNM)";
                else if (ex.Message.Contains("Error Number = 20102"))
                    response.Message = "Invalid tax detail ID (TAXDTLID) - it does not exist in the TX00201";
                else if (ex.Message.Contains("Error Number = 833"))
                    response.Message = "Invalid Purchase Item Tax Schedule";
                else if (ex.Message.Contains("Error Number = 7194"))
                    response.Message = "POP Line tax total does not equal the tax amount (TAXAMNT)";

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


        private GeneralResponceApi AssignVendors(ReceivingTransaction receivingTransaction)
        {
            var result = receivingTransaction.POPLines.Select(x => new ItemVendor
            {
                ITEMNMBR = x.ITEMNMBR,
                VENDORID = x.VENDORID,
                VNDITNUM = x.VNDITNUM,
            }).ToList();
            var res = _itemVendorService.CreateUpdateItemVendors(result);
            return res;
        }
        //public GeneralResponceApi UpdatePOP(ReceivingTransaction receivingTransaction)
        //{
        //    GeneralResponceApi response = new GeneralResponceApi();
        //    try
        //    {

        //        using (eConnectMethods eConnect = new eConnectMethods())
        //        {

        //            eConnectType UpdatePOPType = new eConnectType();

        //            UpdatePOPType.POPReceivingsType = new POPReceivingsType[]
        //            {
        //                new POPReceivingsType
        //                {
        //                    taPopRcptHdrInsert=receivingTransaction.POPHeader,

        //                    taPopRcptLineInsert_Items= receivingTransaction.POPLines.ToTaPopRECPLineInsertArray(),

        //                }
        //            };
        //            string xml = GeneralOperationObject.SerializeObject(UpdatePOPType);
        //            var result = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
        //            if (result)
        //            {
        //                response.IsSuccess = true;
        //                response.Message = "this transaction hase been Successfuly";
        //            }
        //            else
        //            {
        //                response.IsSuccess = false;
        //                response.Message = "this transaction hase been failed";
        //            }
        //        }
        //    }
        //    catch (eConnectException ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //        //if (ex.Message.Contains("Error Number = 9539"))

        //        //    response.Message = "The Salesperson is set to inactive in the Salesperson Master Table - RM00301.";

        //        //else
        //        //    response.Message = ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //    }

        //    return response;
        //}
        //public GeneralResponceApi UpdatePOPLine(POPLine pOPLine)
        //{
        //    GeneralResponceApi response = new GeneralResponceApi();
        //    try
        //    {

        //        using (eConnectMethods eConnect = new eConnectMethods())
        //        {
        //            eConnectType UpdatePOPLineType = new eConnectType();
        //            UpdatePOPLineType.POPReceivingsType = new POPReceivingsType[]
        //            {
        //                new POPReceivingsType
        //                {

        //                    taPopRcptLineInsert_Items= new taPopRcptLineInsert_ItemsTaPopRcptLineInsert[]{ pOPLine }
        //                }
        //            };
        //            string xml = GeneralOperationObject.SerializeObject(UpdatePOPLineType);
        //            var result = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, xml);
        //            if (result)
        //            {
        //                response.IsSuccess = true;
        //                response.Message = "this transaction hase been Successfuly";
        //            }
        //            else
        //            {
        //                response.IsSuccess = false;
        //                response.Message = "this transaction hase been failed";
        //            }
        //        }
        //    }
        //    catch (eConnectException ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //        //if (ex.Message.Contains("Error Number = 9539"))

        //        //    response.Message = "The Salesperson is set to inactive in the Salesperson Master Table - RM00301.";

        //        //else
        //        //    response.Message = ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //    }

        //    return response;
        //}

    }
}
