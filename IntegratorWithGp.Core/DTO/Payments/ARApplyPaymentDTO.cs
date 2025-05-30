using System;

namespace IntegratorWithGp.Core.DTO.Payments
{
    public class ARApplyPaymentDTO
    {
        public decimal AmountApplied { get; set; }
        public DateTime? AppliedToDocumentDate { get; set; }
        public DateTime? ApplyDocumentDate { get; set; }
        public string AppliedToDocTypeName { get; set; }
        public string AppliedToDocNumber { get; set; }
        public string DocumentNumber { get; set; }
        public decimal? ExchangeRate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string ShipmentNumber { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string ClientOrderNo { get; set; }
        public string BillOfLading { get; set; }
        public string CurrencyID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }


    }
}
