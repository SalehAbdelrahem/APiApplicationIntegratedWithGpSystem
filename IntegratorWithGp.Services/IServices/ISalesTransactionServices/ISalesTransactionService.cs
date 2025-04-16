using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.SalesTransactions;

namespace IntegratorWithGp.Services.IServices.ISalesTransactionServices
{
    public interface ISalesTransactionService
    {
        GeneralResponceApi CreateSOP(SalesTransaction salesTransaction);
        GeneralResponceApi UpdateSOPLine(SOPLine sOPLine);
        GeneralResponceApi DeleteSOPLine(DeleteSOPLine sOPLine);
    }
}
