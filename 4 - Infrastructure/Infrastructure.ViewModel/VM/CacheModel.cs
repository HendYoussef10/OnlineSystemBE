using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ViewModel.VM.User
{
    public class CacheModel
    {
        public string? UserId { set; get; }
        public string? Email { set; get; }
        public string? UserName { set; get; }
        public string? Token { set; get; }
        public string? RefreshToken { set; get; }
        public string? Role { set; get; }
        public Guid RoleId { set; get; }
        public string? Image { get; set; }
        public string? PhoneNumber{ set; get; }
    }
}
