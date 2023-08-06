using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel.Response
{
    public class ResUser
    {
        public string Id { set; get; }
        public string UserName { set; get; }
        public string Image { get; set; }
        public bool PhoneNumberConfirmed { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public List<ResUserRole> UserRoles { set; get; }
}
}
