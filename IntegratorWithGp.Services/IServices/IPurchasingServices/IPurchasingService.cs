using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;

namespace IntegratorWithGp.Services.IServices.IPurchasingServices
{
    public interface IPurchasingService
    {
        GeneralResponceApi InsertPayablesTransaction(PMTransactionEntry pMTransactionEntry);
    }
}
