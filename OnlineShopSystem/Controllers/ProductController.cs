using Infrastructure.ViewModel.Request.Products;
using Infrastructure.ViewModel.Response;
using Infrastructure.ViewModel.Response.Product;
using Infrastructure.ViewModel.VM;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace OnlineSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        protected readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<List<ResProduct>>), 200)]
        public IActionResult GetAllProduct()
        {
            var result = service.GetAllProducts();
            return Ok(new SuccessResponse<List<ResProduct>>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpPost("GetProductsPagination")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<List<ResProduct>>), 200)]
        public IActionResult GetProductsPagination(PageInfo pageInfo)
        {
            var result = service.GetProductsPaging(pageInfo);
            return Ok(new SuccessResponse<List<ResProduct>>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpGet("GetProductById")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<ResProduct>), 200)]
        public IActionResult GetProductById(Guid Id)
        {
            var result = service.GetProductById(Id);
            return Ok(new SuccessResponse<ResProduct>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<bool>), 200)]
        public IActionResult CreateProduct(ReqCreateProduct req)
        {
            var result = service.CreateProduct(req);
            return Ok(new SuccessResponse<bool>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpPut("UpdateProduct")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<bool>), 200)]
        public IActionResult UpdateProduct(ReqUpdateProduct req)
        {
            var result = service.UpdateProduct(req);
            return Ok(new SuccessResponse<bool>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<bool>), 200)]
        public IActionResult DeleteProduct(Guid id)
        {
            var result = service.DeleteProduct(id);
            return Ok(new SuccessResponse<bool>
            {
                Code = 200,
                Data = result
            });
        }

        [HttpGet("GetProductsCount")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<int>), 200)]
        public IActionResult GetProductsCount()
        {
            var result = service.GetProductsCount();
            return Ok(new SuccessResponse<int>
            {
                Code = 200,
                Data = result
            });
        }

    }
}
