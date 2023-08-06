using AutoMapper;
using Domain.Configration.EntitiesProperties;
using Domain.Entities.Entities;
using Infrastructure.ViewModel.Request.Products;
using Infrastructure.ViewModel.Response.Product;
using Infrastructure.ViewModel.VM;
using Newtonsoft.Json;
using Persistence.IRepository;
using Service.Interface;
using Service.Interface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly IMapper mapper;
        private readonly ICacheProductService productCache;
        public ProductService(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper, ICacheProductService productCache)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.productCache = productCache;
        }

        public bool CreateProduct(ReqCreateProduct req)
        {
            var mappedProduct = mapper.Map<Product>(req);
            bool isValid = CheckProductValidation(mappedProduct);
            if (isValid)
            {
                var repo = unitOfWork.GetRepository<Product>();

                repo.Add(mappedProduct);
                productCache.RemoveData("products");
                var result = unitOfWork.SaveChanges();

                if (result > 0)
                    return true;
            }
            return false;
        }

        public bool DeleteProduct(Guid id)
        {
            var repo = unitOfWork.GetRepository<Product>();

            Product obj = repo.GetSingle(id);

            if (obj == null)
                throw new Exception("This product not found");

            repo.DeleteWhere(i=>i.Id==id);
            productCache.RemoveData("products");
            var result = unitOfWork.SaveChanges();

            if (result > 0)
                return true;
            return false;
        }
        public bool UpdateProduct(ReqUpdateProduct req)
        {
            var repo = unitOfWork.GetRepository<Product>();

            var oldProduct = repo.GetSingle(req.Id);
            if (oldProduct == null)
                throw new Exception("Product Not Found");

            mapper.Map(req, oldProduct);

            repo.Update(oldProduct);
            productCache.RemoveData("products");
            var result = unitOfWork.SaveChanges();

            if (result > 0)
                return true;

            return false;
        }
        public ResProduct GetProductById(Guid Id)
        {
            var repo = unitOfWork.GetRepository<Product>();

            var tbl_product = repo.GetSingle(x => !x.IsDeleted && x.Id == Id, x => x.Category);

            ResProduct product = mapper.Map<ResProduct>(tbl_product);

            return product;
        }
        public List<ResProduct> GetProductsPaging(PageInfo pageInfo)
        {
            var repo = unitOfWork.GetRepository<Product>();

            var res = repo.GetAllWithTakeAndSkipWithOrdering((pageInfo.NeededPage - 1) * pageInfo.PageSize
                , pageInfo.PageSize, x => x.Name!, x => x.Category);

            List<ResProduct> mapRes = mapper.Map<List<ResProduct>>(res);

            return mapRes;
        }
        public List<ResProduct> GetAllProducts()
        {
            var repo = unitOfWork.GetRepository<Product>();
            var cacheData = productCache.GetData("products");
            if (cacheData != null)
            {
                return JsonConvert.DeserializeObject<List<ResProduct>>(cacheData);
            }

            var tbl_products = repo.GetAllIncluding(x => !x.IsDeleted, x => x.Category);

            List<ResProduct> products = mapper.Map<List<ResProduct>>(tbl_products);

            if (products != null)
            {
                var json = JsonConvert.SerializeObject(products);
                productCache.SetData("products", json);
            }

            return products;
        }

        public int GetProductsCount()
        {
            var repo = unitOfWork.GetRepository<Product>();   
            var totalProducts = repo.Count();
            return totalProducts;
        }

        private bool CheckProductValidation(Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Description) || string.IsNullOrEmpty(product.Name)
                || string.IsNullOrEmpty(product.Image) || product.Price <= 0)
            {
                return false;
            }
            return true;

        }
    }
}
