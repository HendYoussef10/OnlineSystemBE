using AutoMapper;
using Domain.Configration.EntitiesProperties;
using Domain.Entities;
using Infrastructure.Utilities.Exceptions;
using Infrastructure.ViewModel.Request;
using Infrastructure.ViewModel.Response;
using Infrastructure.ViewModel.VM.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence.IRepository;
using Persistence.IRepository.IUserRepository;
using Service.Interface;
using Service.Utilities.BuilderUtilities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.ViewModel.VM;

namespace Service.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly IRoleService roleService;
        private readonly IUtilitesBuilder utilitesBuilder;
        private readonly ITokenService tokenService;
        private readonly ICacheService cacheService;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork<AppDbContext> unitOfWork,
            IUtilitesBuilder utilitesBuilder,
            IRoleService roleService,
            ITokenService tokenService,
            ICacheService cacheService
        )
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.utilitesBuilder = utilitesBuilder;
            this.roleService = roleService;
            this.tokenService = tokenService;
            this.cacheService = cacheService;
        }

        private async Task<User> GetUserByEmail(string email)
        {
            var user = new User();
            user = await userRepository.FindUser(e => e.Email.Equals(email.Trim())
                             || e.Email.Equals(email.Trim()));
            return user;
        }
        private async Task<User> GetUserById(string Id)
        {
            var user = new User();
            user = await userRepository.FindUser(e => e.Id.Equals(Id.Trim())
                             || e.Id.Equals(Id.Trim()));
            return user;
        }
        private async Task<bool> CheckPassword(User user,string password)
        {
            password = this.utilitesBuilder.BuildText().Base64Decode(password);
            var checkPassword = await userRepository.CheckPasswordAsync(user, password);

            return checkPassword;
        }

        private ResRole GetUserRole(User user)
        {
            var roles = this.userRepository.GetRolesAsync(user);

            var roleList = roleService.GetAllRoles();

            var role = roleList.Find(e => e.Name!.Equals(roles));

            return role!;
        }

        public async Task<CacheModel> Login(ReqLogin model)
        {
            var user = new User();

            if (model.Email != null && model.Email != string.Empty)
            {

                user = await GetUserByEmail(model.Email);

                if (user == null)
                    throw new Exception("Your Mail Is Not Correct!");

                if (user == null || user.IsDeleted)
                    throw new Exception("No Users Found!");

                var isCorrectPassword = await CheckPassword(user,model.Password!);
                
                if (!isCorrectPassword)
                    throw new Exception("Your UserName Or Password Is Not Correct!");
            }


            var Role = GetUserRole(user);
            var cache = tokenService.CreateTokenAll(user, Role.Name!, Role.Id);


            return cache;
        }

        public async Task<CacheModel> RefreshToken(RefreshTokenModel model)
        {

            var cache = cacheService.GetCache(model.RefreshToken!);
            if (cache == null)
                throw new HandeleException(113, "This Refresh Token Is Invalid!");

            var user = await GetUserById(cache.UserId!);
           
            if (user == null)
                throw new Exception("User Not Found!");
            
            var role = GetUserRole(user);

            var newCache = tokenService.CreateTokenAll(user, role.Name!, role.Id);

            return newCache;
        }
    }
}
