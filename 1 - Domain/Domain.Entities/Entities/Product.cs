using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Product : EntityBase
    {
        public Guid CategoryId { set; get; }
        public string? Description { set; get; }
        public string? Name { set; get; }
        public string? NameEn { set; get; }
        public bool HasAvailableStock { set; get; }
        public decimal Price { set; get; }
        public string? Image { set; get; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}
