using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Customers;
using IntegratorWithGp.Services.Iservices.ICustomerServices;

namespace IntegratorWithGP.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _CustomerService;
        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }


        // POST api/Customers

        public IHttpActionResult Post([FromBody] Customer data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _CustomerService.CreateUpdate(data);

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
