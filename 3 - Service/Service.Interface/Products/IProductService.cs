using Infrastructure.ViewModel.Request.Products;
using Infrastructure.ViewModel.Response.Product;
using Infrastructure.ViewModel.VM;

namespace Service.Interface
{
    public interface IProductService
    {
        List<ResProduct> GetProductsPaging(PageInfo pageInfo);
        List<ResProduct> GetAllProducts();
        ResProduct GetProductById(Guid Id);        
        bool CreateProduct(ReqCreateProduct req);
        bool UpdateProduct(ReqUpdateProduct req);
        bool DeleteProduct(Guid id);
        int GetProductsCount();
    }
}
