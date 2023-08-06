using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Category : EntityBase
    {
        public string? Name { set; get; }
        public virtual ICollection<Product>? Products { set; get; }

    }
}
