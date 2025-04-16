using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Items;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using IntegratorWithGp.Services.IServices.IItemServices;
using IntegratorWithGp.Services.IServices.IPurchasingServices;
using IntegratorWithGP.Areas.HelpPage;

namespace IntegratorWithGP.Controllers
{
    [RoutePrefix("api/Purchasings")]
    public class PurchasingsController : ApiController
    {
        private readonly IPurchasingService _purchasingService;
        public PurchasingsController(IPurchasingService  purchasingService)
        {
            _purchasingService = purchasingService;
        }

        [HttpPost]
        [Route(nameof(PayablesTransactionEntry))]
        public IHttpActionResult PayablesTransactionEntry(PayableTransaction data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _purchasingService.InsertPayablesTransaction(data);

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