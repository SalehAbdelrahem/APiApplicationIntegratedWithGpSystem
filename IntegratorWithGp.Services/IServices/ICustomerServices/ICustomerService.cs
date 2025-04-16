using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Customers;

namespace IntegratorWithGp.Services.Iservices.ICustomerServices
{
    public interface ICustomerService
    {
        GeneralResponceApi CreateUpdate(Customer customer);
    }
}
