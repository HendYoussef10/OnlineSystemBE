using Infrastructure.ViewModel.Request;
using Infrastructure.ViewModel.Response;
using Infrastructure.ViewModel.VM;
using Infrastructure.ViewModel.VM.User;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace OnlineSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        protected readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<CacheModel>), 200)]
        public async Task<SuccessResponse<CacheModel>> Login(ReqLogin model)
        {
            var result = await service.Login(model);
            return new SuccessResponse<CacheModel>
            {
                Code = 200,
                Data = result
            };
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(FailureResponse), 500)]
        [ProducesResponseType(typeof(SuccessResponse<CacheModel>), 200)]
        public async Task<SuccessResponse<CacheModel>> RefreshToken(RefreshTokenModel model)
        {
            var result = await service.RefreshToken(model);
            return new SuccessResponse<CacheModel>
            {
                Code = 200,
                Data = result
            };
        }
    }
}
