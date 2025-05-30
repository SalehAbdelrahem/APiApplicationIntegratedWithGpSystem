using System;

namespace IntegratorWithGp.Core.DTO.Payments
{
    public class ARApplyPaymentDTO
    {
        public string AmountApplied { get; set; } = string.Empty;
        public DateTime AppliedToDocumentDate { get; set; }
        public DateTime ApplyDocumentDate { get; set; }
        public string AppliedToDocTypeName { get; set; } = string.Empty;
        public string AppliedToDocNumber { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string ExchangeRate { get; set; } = string.Empty;
        public string DocumentDate { get; set; } = string.Empty;
        public string ShipmentNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string ClientOrderNo { get; set; } = string.Empty;
        public string BillOfLading { get; set; } = string.Empty;
        public string CurrencyId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

    }
}
