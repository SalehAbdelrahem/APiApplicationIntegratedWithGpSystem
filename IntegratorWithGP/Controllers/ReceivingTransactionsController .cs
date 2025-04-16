using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.ReceivingTransactions;
using IntegratorWithGp.Services.IServices.IReceivingTransactionEntityServices;

namespace IntegratorWithGP.Controllers
{
    public class ReceivingTransactionsController : ApiController
    {
        private readonly IReceivingTransactionEntityService _receivingTransactionEntityService;

        public ReceivingTransactionsController(IReceivingTransactionEntityService receivingTransactionEntityService)
        {
            _receivingTransactionEntityService = receivingTransactionEntityService;
        }
        public IHttpActionResult Post([FromBody] ReceivingTransaction data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _receivingTransactionEntityService.CreatePOP(data);

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
        //public IHttpActionResult put([FromBody] ReceivingTransaction data)
        //{
        //    if (data == null)
        //    {
        //        return BadRequest("Input data cannot be null.");
        //    }

        //    try
        //    {
        //        // Call the synchronous service method
        //        GeneralResponceApi result = _receivingTransactionEntityService.UpdatePOP(data);

        //        // Return success response
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result);
        //        }

        //        // Return failure response with details
        //        return Content(HttpStatusCode.BadRequest, result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(new Exception("An internal error occurred.", ex));
        //    }
        //}
        // PUT api/values/5
        //public IHttpActionResult put([FromBody] POPLine data)
        //{
        //    if (data == null)
        //    {
        //        return BadRequest("Input data cannot be null.");
        //    }

        //    try
        //    {
        //        // Call the synchronous service method
        //        GeneralResponceApi result = _receivingTransactionEntityService.UpdatePOPLine(data);

        //        // Return success response
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result);
        //        }

        //        // Return failure response with details
        //        return Content(HttpStatusCode.BadRequest, result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(new Exception("An internal error occurred.", ex));
        //    }
        //}

    }
}
