using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratorWithGp.Services.IServices.IPaymentServices
{
    public interface IPaymentService<T>
    {
       ApiResponse<List<T>> GetARApplyPayment(string customerId);
    }
}
