using System;
using System.Net;
using System.Web.Http;
using IntegratorWithGp.Core.DTO.ResponseApi;
using IntegratorWithGp.Core.Models.Vendors;
using IntegratorWithGp.Services.Iservices.IVendorService;

namespace IntegratorWithGP.Controllers
{
    public class VendorsController : ApiController
    {
        private readonly IVendorService _VendorService;
        public VendorsController(IVendorService VendorService)
        {
            _VendorService = VendorService;
        }
        public IHttpActionResult Post([FromBody] Vendor data)
        {
            if (data == null)
            {
                return BadRequest("Input data cannot be null.");
            }

            try
            {
                // Call the synchronous service method
                GeneralResponceApi result = _VendorService.CreateUpdate(data);

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

