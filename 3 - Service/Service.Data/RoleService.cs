using AutoMapper;
using Domain.Configration.EntitiesProperties;
using Domain.Entities;
using Infrastructure.ViewModel.Response;
using Microsoft.AspNetCore.Identity;
using Persistence.IRepository;
using Persistence.IRepository.IUserRepository;
using Service.Interface;

namespace Service.Data
{
    public class RoleService : IRoleService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly IRoleRepository roleRepository;

        public RoleService(
            IUnitOfWork<AppDbContext> unitOfWork,
            IMapper mapper,
            IRoleRepository roleRepository
        )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
        }
        public List<ResRole> GetAllRoles()
        {
            var role = roleRepository.GetAllRole();

            var resRole = mapper.Map<List<ResRole>>(role);

            return resRole;
        }

    }
}
