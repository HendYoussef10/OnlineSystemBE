using Domain.Entities;
using Infrastructure.ViewModel.Base;
using Infrastructure.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel.Profiles
{
    public class RoleProfile : ProfileBase
    {
        public override void Request()
        {
        }

        public override void Response()
        {
            CreateMap<Role, ResRole>();
            CreateMap<UserRole, ResUserRole>();
            
        }
    }
}
