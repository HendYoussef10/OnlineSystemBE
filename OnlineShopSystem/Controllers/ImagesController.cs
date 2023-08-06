using Infrastructure.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using Service.Utilities.BuilderUtilities;

namespace EDUHuB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController
    {
        private readonly IUtilitesBuilder utilitesBuilder;
        public ImagesController(IUtilitesBuilder utilitesBuilder)
        {
            this.utilitesBuilder = utilitesBuilder;
        }

        [HttpPost("UploadImages")]
        [RequestSizeLimit(100_000_000)]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<List<string>>), 200)]
        public async Task<SuccessResponse<List<string>>> UploadImages([FromForm] IFormFile image)
        {
            var img = utilitesBuilder.BuildImage();
            var result = await img.UploadImages(image);

            return new SuccessResponse<List<string>>
            {
                Code = 200,
                Data = result
            };
        }

    }
}
