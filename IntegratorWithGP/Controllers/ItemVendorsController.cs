//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Web.Http;
//using IntegratorWithGp.Core.DTO.ResponseApi;
//using IntegratorWithGp.Core.Models.ItemVendors;
//using IntegratorWithGp.Services.IServices.IItemVendorServices;

//namespace IntegratorWithGP.Controllers
//{
//    public class ItemVendorsController : ApiController
//    {
//        private readonly IItemVendorService _iItemVendorService;
//        public ItemVendorsController(IItemVendorService iItemVendorService)
//        {
//            _iItemVendorService = iItemVendorService;
//        }
//        public IHttpActionResult Put([FromBody] List<ItemVendor> data)
//        {
//            if (data == null)
//            {
//                return BadRequest("Input data cannot be null.");
//            }

//            try
//            {
//                GeneralResponceApi result = _iItemVendorService.CreateUpdateItemVendors(data);

//                if (result.IsSuccess)
//                {
//                    return Ok(result);
//                }
//                return Content(HttpStatusCode.BadRequest, result);
//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(new Exception("An internal error occurred.", ex));
//            }
//        }

//    }
//}
