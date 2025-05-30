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
                        AmountApplied = row["Amount_Applied"]?.ToString() ?? string.Empty,
                        AppliedToDocumentDate = row.Field<DateTime>("Applied_to_Document_Date"),
                        ApplyDocumentDate = row.Field<DateTime>("Apply_Document_Date"),
                        AppliedToDocTypeName = row["Applied_to_Doc_Type_Name"]?.ToString() ?? string.Empty,
                        AppliedToDocNumber = row["Applied_to_Doc_Number"]?.ToString() ?? string.Empty,
                        DocumentNumber = row["Document_Number"]?.ToString() ?? string.Empty,
                        ExchangeRate = row["Exchange Rate"]?.ToString() ?? string.Empty,
                        DocumentDate = row["Document_Date"]?.ToString() ?? string.Empty,
                        //ShipmentNumber = row["Shipment number"]?.ToString() ?? string.Empty,
                       // Department = row["Department"]?.ToString() ?? string.Empty,
                       // Branch = row["Branch"]?.ToString() ?? string.Empty,
                       // ClientOrderNo = row["Client order No"]?.ToString() ?? string.Empty,
                       // BillOfLading = row["Bill of lading"]?.ToString() ?? string.Empty,
                        CurrencyId = row["Currency ID"]?.ToString() ?? string.Empty,
                        CustomerId = row["Customer_ID"]?.ToString() ?? string.Empty,
                        CustomerName = row["Customer_Name"]?.ToString() ?? string.Empty
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
