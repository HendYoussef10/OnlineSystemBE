using Persistence.IRepository.IUserRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Configration.EntitiesProperties;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Domain.Entities;

namespace Persistence.Repository.UserRepository
{
    public class RoleRepository : IRoleRepository
    {
        protected readonly DbSet<Role> DbSet;

        public RoleRepository(RoleManager<Role> roleManager, AppDbContext context)
        {
            DbSet = context.Set<Role>();

        }

        public List<Role> GetAllRole()
        {
            return DbSet.ToList();
        }

     
        public Role GetRoleById(string pId)
        {
            return DbSet.Where(e => e.Id.Equals(pId)).FirstOrDefault();
        }
    }
}
