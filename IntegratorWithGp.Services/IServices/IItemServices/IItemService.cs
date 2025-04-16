using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Items;

namespace IntegratorWithGp.Services.IServices.IItemServices
{
    public interface IItemService
    {
        GeneralResponceApi CreateUpdate(Item item);

    }
}
