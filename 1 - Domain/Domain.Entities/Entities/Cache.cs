using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Cache : EntityBase
    {
        public string? UserId { set; get; }
        [ForeignKey("UserId")]
        public User? User { set; get; }
        public string? Token { set; get; }
        public string? RefreshToken { set; get; }
        public string? Role { set; get; }
        public string? RoleId { set; get; }       
        [ForeignKey("RoleId")]
        public Role? Tbl_Role { set; get; }
    }
}
