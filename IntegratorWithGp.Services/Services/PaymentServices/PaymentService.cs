using IntegratorWithGp.Core.DTO.Payments;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Services.IServices.IPaymentServices;
using IntegratorWithGp.Services.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;

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

            string query = $@"SELECT[Amount_Applied]
      ,[Applied_to_Document_Date]
      ,[Apply_Document_Date]
      ,[Applied_to_Doc_Type_Name]
      ,[Applied_to_Doc_Number]
      ,[Document_Number]
      ,[Exchange Rate]
      ,[Document_Date]
      ,[Shipment number]
      ,[Department]
      ,[Branch]
      ,[Client order No]
      ,[Bill of lading]
      ,[Currency ID]
      ,[Customer_ID]
      ,[Customer_Name]
            FROM[dbo].[view_AR_Apply_Detail_AR2]
                                where [Customer_ID]='{customerId}'";

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
                        AmountApplied = row.Field<decimal>("Amount_Applied"),
                        AppliedToDocumentDate = row.Field<DateTime?>("Applied_to_Document_Date"),
                        ApplyDocumentDate = row.Field<DateTime?>("Apply_Document_Date"),
                        AppliedToDocTypeName = row.Field<string>("Applied_to_Doc_Type_Name"),
                        AppliedToDocNumber = row.Field<string>("Applied_to_Doc_Number"),
                        DocumentNumber = row.Field<string>("Document_Number"),
                        ExchangeRate = row.Field<decimal?>("Exchange Rate"),
                        DocumentDate = row.Field<DateTime?>("Document_Date"),
                        ShipmentNumber = row.Field<string>("Shipment number"),
                        Department = row.Field<string>("Department"),
                        Branch = row.Field<string>("Branch"),
                        ClientOrderNo = row.Field<string>("Client order No"),
                        BillOfLading = row.Field<string>("Bill of lading"),
                        CurrencyID = row.Field<string>("Currency ID"),
                        CustomerID = row.Field<string>("Customer_ID"),
                        CustomerName = row.Field<string>("Customer_Name")
                    });
                }

                return new ApiResponse<List<ARApplyPaymentDTO>>
                {
                   
                    IsSuccess = result.Any(),
                    Message = "Data retrieved successfully.",
                    Data = result
                };
            }
          
        }
    }
}
