using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Purchasing.TransactionEntries;
using IntegratorWithGp.Core.Models.SalesTransactions;
using IntegratorWithGp.Services.IServices.IPurchasingServices;
using IntegratorWithGp.Services.IServices.ISales;

namespace IntegratorWithGP.Controllers
{
    [RoutePrefix("api/Sales")]

    public class SalesController : ApiController
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        [Route(nameof(InsertReceivableTransaction))]
        public IHttpActionResult InsertReceivableTransaction(ReceivableTransaction data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _salesService.InsertReceivableTransaction(data);

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

        [HttpPost]
        [Route(nameof(Test))]
        public IHttpActionResult Test() {

            
            return Ok(_salesService.test()); 
        }

    }
}
