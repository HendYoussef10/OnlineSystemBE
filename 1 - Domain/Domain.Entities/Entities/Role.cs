using Microsoft.AspNetCore.Identity;


namespace Domain.Entities
{
    public class Role : IdentityRole<string>
    {
        public bool IsDeleted { set; get; }
        public virtual ICollection<UserRole>? UserRoles { set; get; }
    }
}
