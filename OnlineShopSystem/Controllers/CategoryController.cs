using Infrastructure.ViewModel.Response;
using Infrastructure.ViewModel.Response.Products;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace OnlineSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        protected readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<List<ResCategory>>), 200)]
        public IActionResult GetAllCategories()
        {
            var result = service.GetAllCategories();
            return Ok(new SuccessResponse<List<ResCategory>>
            {
                Code = 200,
                Data = result
            });
        }

    }
}
