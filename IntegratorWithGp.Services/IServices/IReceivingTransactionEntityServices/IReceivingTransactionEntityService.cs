using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.ReceivingTransactions;
using IntegratorWithGp.Core.Models.SalesTransactions;

namespace IntegratorWithGp.Services.IServices.IReceivingTransactionEntityServices
{
    public interface IReceivingTransactionEntityService
    {
        GeneralResponceApi CreatePOP(ReceivingTransaction receivingTransaction);
        //GeneralResponceApi UpdatePOP(ReceivingTransaction receivingTransaction);
        //GeneralResponceApi UpdatePOPLine(POPLine pOPLine);
    }
}
