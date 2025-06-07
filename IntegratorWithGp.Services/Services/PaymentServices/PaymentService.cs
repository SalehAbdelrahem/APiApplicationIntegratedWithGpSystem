using IntegratorWithGp.Core.DTO.Payments;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Services.IServices.IPaymentServices;
using IntegratorWithGp.Services.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntegratorWithGp.Services.Services.PaymentServices
{
    public class PaymentService : IPaymentService<ARApplyPaymentDTO>
    {
        private readonly EconnectServices _econnectServices;

        public PaymentService(EconnectServices econnectServices)
        {
            _econnectServices = econnectServices;
        }
        public ApiResponse<List<ARApplyPaymentDTO>> GetARApplyPayment(string customerId)

        {
            #region old 
            //string query = $@"SELECT
            //                           [Amount_Applied]
            //                          ,[Applied_to_Document_Date]
            //                          ,[Apply_Document_Date]
            //                          ,[Applied_to_Doc_Type_Name]
            //                          ,[Applied_to_Doc_Number]
            //                          ,[Document_Number]
            //                          ,[Exchange Rate]
            //                          ,[Document_Date]
            //                          ,[Shipment number]
            //                          ,[Department]
            //                          ,[Branch]
            //                          ,[Client order No]
            //                          ,[Bill of lading]
            //                          ,[Currency ID]
            //                          ,[Customer_ID]
            //                          ,[Customer_Name]
            //                           FROM[dbo].[view_AR_Apply_Detail_AR2]
            //                           where [Customer_ID]='{customerId}'";
            #endregion
           

            string query = $@"SELECT   [Customer ID]
                                      ,[Invoice Number]
                                      ,[Remrning_Amount]
                                      ,[CURTRXAM]
                                      ,[ORTRXAMT]
                                      ,[CURNCYID]
                                      ,[XCHGRATE]
                                      ,[Currency amount]
                                      ,[RMDTYPAL]
                                       FROM [dbo].[AR_Remaining_Amount]
                                       where [Customer ID]='{customerId}'";

            var data =  _econnectServices.OpenConnectionGp(query);
            var result = new List<ARApplyPaymentDTO>();
            if (data.HasErrors)
            {
                return new ApiResponse<List<ARApplyPaymentDTO>>
                {

                    Message = "failed retrieve Data "
                };
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    result.Add(new ARApplyPaymentDTO
                    {
                        #region old
                        //AmountApplied = row.Field<decimal>("Amount_Applied"),
                        //AppliedToDocumentDate = row.Field<DateTime?>("Applied_to_Document_Date"),
                        //ApplyDocumentDate = row.Field<DateTime?>("Apply_Document_Date"),
                        //AppliedToDocTypeName = row.Field<string>("Applied_to_Doc_Type_Name")?.Trim(),
                        //AppliedToDocNumber = row.Field<string>("Applied_to_Doc_Number")?.Trim(),
                        //DocumentNumber = row.Field<string>("Document_Number")?.Trim(),
                        //ExchangeRate = row.Field<decimal?>("Exchange Rate"),
                        //DocumentDate = row.Field<DateTime?>("Document_Date"),
                        //ShipmentNumber = row.Field<string>("Shipment number")?.Trim(),
                        //Department = row.Field<string>("Department")?.Trim(),
                        //Branch = row.Field<string>("Branch")?.Trim(),
                        //ClientOrderNo = row.Field<string>("Client order No")?.Trim(),
                        //BillOfLading = row.Field<string>("Bill of lading")?.Trim(),
                        //CurrencyID = row.Field<string>("Currency ID")?.Trim(),
                        //CustomerID = row.Field<string>("Customer_ID")?.Trim(),
                        //CustomerName = row.Field<string>("Customer_Name")?.Trim()
                        #endregion
                        CustomerID = row["Customer ID"]?.ToString()?.Trim(),
                        InvoiceNumber = row["Invoice Number"]?.ToString()?.Trim(),
                        RemrningAmount = row["Remrning_Amount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["Remrning_Amount"]),
                        CURTRXAM = row["CURTRXAM"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["CURTRXAM"]),
                        ORTRXAMT = row["ORTRXAMT"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["ORTRXAMT"]),
                        CURNCYID = row["CURNCYID"]?.ToString()?.Trim(),
                        XCHGRATE = row["XCHGRATE"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["XCHGRATE"]),
                        CurrencyAmount = row["Currency amount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["Currency amount"]),
                        RMDTYPAL = row["RMDTYPAL"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["RMDTYPAL"])
                    });
                }

                return new ApiResponse<List<ARApplyPaymentDTO>>
                {

                    IsSuccess = result.Any(),
                    Message = result.Any() ? "Data retrieved successfully." : $"Data Not Found for Customer Id = {customerId}",
                    Data = result
                };
            }

        }
    }
}
