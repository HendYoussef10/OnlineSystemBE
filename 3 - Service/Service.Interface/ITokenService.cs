using Domain.Entities;
using Infrastructure.ViewModel.VM.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITokenService
    {
        public CacheModel CreateTokenAll(User user, string roleName, Guid roleId);
    }
}
