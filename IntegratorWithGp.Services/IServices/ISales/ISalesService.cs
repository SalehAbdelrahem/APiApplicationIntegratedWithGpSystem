using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.SalesTransactions;

namespace IntegratorWithGp.Services.IServices.ISales
{
    public interface ISalesService
    {

        GeneralResponceApi InsertReceivableTransaction(ReceivableTransaction receivableTransaction);
        string test();
    }
}
