using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository.IUserRepository
{
    public interface IRoleRepository
    {
        public List<Role> GetAllRole();
        public Role GetRoleById(string pId);

    }
}
