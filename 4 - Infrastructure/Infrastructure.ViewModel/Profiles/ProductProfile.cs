using Domain.Entities.Entities;
using Infrastructure.ViewModel.Base;
using Infrastructure.ViewModel.Request.Products;
using Infrastructure.ViewModel.Response.Product;
using Infrastructure.ViewModel.Response.Products;


namespace Infrastructure.ViewModel.Profiles
{
    public class ProductProfile : ProfileBase
    {
        public override void Request()
        {
            CreateMap<ReqCreateProduct, Product>();
            CreateMap<ReqUpdateProduct, Product>();
        }

        public override void Response()
        {
            CreateMap<Product, ResProduct>();
            CreateMap<Category, ResCategory>();
        }
    }
}
