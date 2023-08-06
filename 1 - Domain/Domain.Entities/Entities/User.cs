
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateOfCreate { private set; get; } = DateTime.Now;
        public bool IsDeleted { set; get; }

        public virtual ICollection<Cache> Caches { set; get; }
        public virtual ICollection<UserRole> UserRoles { set; get; }

    }
}
