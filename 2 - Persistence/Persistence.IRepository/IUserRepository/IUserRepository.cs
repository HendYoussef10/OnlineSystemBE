
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
    public interface IUserRepository
    {
        Task<User> FindUser(Expression<Func<User, bool>> predicate);
        string GetRolesAsync(User pUser);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}