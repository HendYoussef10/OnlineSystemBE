using Infrastructure.ViewModel.Response.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService
    {
        public List<ResCategory> GetAllCategories();
    }
}
