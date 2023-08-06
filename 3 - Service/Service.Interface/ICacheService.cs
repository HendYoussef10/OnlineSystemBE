using Domain.Entities;
using Infrastructure.ViewModel.VM.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICacheService
    {
        public CacheModel GetCache(string RefreshToken);
        public void SetUser(string userId, CacheModel model);
        public void RemoveUser(string userId);
        public bool CheckToken(string Token);
    }
}
