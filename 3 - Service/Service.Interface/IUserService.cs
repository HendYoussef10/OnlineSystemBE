
using Infrastructure.ViewModel.Request;
using Infrastructure.ViewModel.Response;
using Infrastructure.ViewModel.VM;
using Infrastructure.ViewModel.VM.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Service.Interface
{
    public interface IUserService
    {
        public Task<CacheModel> Login(ReqLogin model);
        public Task<CacheModel> RefreshToken(RefreshTokenModel model);
    }
}
