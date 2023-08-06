using Domain.Entities;
using Infrastructure.ViewModel.Base;
using Infrastructure.ViewModel.VM.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ViewModel.Profiles
{
    public class CacheProfile : ProfileBase
    {
        public override void Request()
        {
            CreateMap<Cache, CacheModel>();
        }

        public override void Response()
        {
            CreateMap<CacheModel,Cache>();
        }
    }
}
