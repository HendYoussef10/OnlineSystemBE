using Domain.Configration.EntitiesProperties;
using Persistence.IRepository.IUserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities;
namespace Persistence.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        protected readonly DbSet<User> DbSet;
        private readonly UserManager<User> userManager;
        public UserRepository(UserManager<User> userManager, AppDbContext context)
        {
            DbSet = context.Set<User>();
            this.userManager = userManager;
        }
       
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<User> FindUser(Expression<Func<User, bool>> predicate)
        {
            return await this.DbSet.Where(predicate).FirstOrDefaultAsync();
        }
        public string GetRolesAsync(User pUser)
        {
            return userManager.GetRolesAsync(pUser).Result.FirstOrDefault();
        }
    }
}