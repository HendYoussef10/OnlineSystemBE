using Domain.Entities;
using Infrastructure.ViewModel.Base;
using Infrastructure.ViewModel.Request;
using Infrastructure.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel.Profiles
{
    public class UserProfile : ProfileBase
    {
        public override void Request()
        {
        }

        public override void Response()
        {
            CreateMap< User, ResUser>();

            


        }
    }
}
