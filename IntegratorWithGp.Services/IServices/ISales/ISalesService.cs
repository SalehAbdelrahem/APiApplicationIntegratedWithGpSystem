using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.SalesTransactions;
using IntegratorWithGp.Core.Models.SalesTransactions.Sales;

namespace IntegratorWithGp.Services.IServices.ISales
{
    public interface ISalesService
    {

        GeneralResponceApi InsertReceivableTransaction(RMTransactionEntry rMTransactionEntry);
        //string test();
    }
}
