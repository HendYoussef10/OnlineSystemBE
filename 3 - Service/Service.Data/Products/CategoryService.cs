using AutoMapper;
using Domain.Configration.EntitiesProperties;
using Domain.Entities.Entities;
using Infrastructure.ViewModel.Response.Products;
using Persistence.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data.Products
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<ResCategory> GetAllCategories()
        {
            var repo = unitOfWork.GetRepository<Category>();
            var res = repo.GetAllIncluding(x => !x.IsDeleted);

            List<ResCategory> mapRes = mapper.Map<List<ResCategory>>(res);

            return mapRes;
        }
    }
}
