using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.SalesTransactions;
using IntegratorWithGp.Services.IServices.ISalesTransactionServices;

namespace IntegratorWithGP.Controllers
{
    public class SalesTransactionsController : ApiController
    {
        private readonly ISalesTransactionService _salesTransactionService;

        public SalesTransactionsController(ISalesTransactionService salesTransactionService)
        {
            _salesTransactionService = salesTransactionService;
        }
        public IHttpActionResult Post([FromBody] SalesTransaction data)
        {


            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _salesTransactionService.CreateSOP(data);

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

        // PUT api/values/5
        public IHttpActionResult put([FromBody] SOPLine data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _salesTransactionService.UpdateSOPLine(data);

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
        public IHttpActionResult delete([FromBody] DeleteSOPLine data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _salesTransactionService.DeleteSOPLine(data);

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
