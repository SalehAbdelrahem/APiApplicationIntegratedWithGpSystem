using IntegratorWithGp.Core.DTO.Payments;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Services.IServices.IPaymentServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace IntegratorWithGP.Controllers
{
    public class PaymentsController : ApiController
    {
        private readonly IPaymentService<ARApplyPaymentDTO> _PaymentService;
        public PaymentsController(IPaymentService<ARApplyPaymentDTO> paymentService)
        {
            _PaymentService = paymentService;
        }
        public IHttpActionResult get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                ApiResponse<List<ARApplyPaymentDTO>> result = _PaymentService.GetARApplyPayment(customerId);

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

