using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Items;
using IntegratorWithGp.Services.IServices.IItemServices;

namespace IntegratorWithGP.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly IItemService _ItemService;
        public ItemsController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }
        // POST api/Items

        public IHttpActionResult Post([FromBody] Item data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _ItemService.CreateUpdate(data);

                // Return success response
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                // Return failure response with details
                return Content(HttpStatusCode.BadRequest, result);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("An internal error occurred.", ex));
            }
        }

    }
}
