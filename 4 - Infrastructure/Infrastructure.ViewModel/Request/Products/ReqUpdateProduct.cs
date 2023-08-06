using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel.Request.Products
{
    public class ReqUpdateProduct
    {
        public Guid Id { set; get; }
        public Guid CategoryId { set; get; }
        public string? Description { set; get; }
        public string? Name { set; get; }
        public string? NameEn { set; get; }
        public bool HasAvailableStock { set; get; }
        public decimal Price { set; get; }
        public string? Image { set; get; }
    }
}
