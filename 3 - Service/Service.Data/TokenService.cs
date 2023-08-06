using Infrastructure.ViewModel.VM.User;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Domain.Configration.EntitiesProperties;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence.IRepository;
using Persistence.IRepository.IUserRepository;
using Service.Interface;
using Service.Utilities.BuilderUtilities;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Service.Data
{
    public class TokenService : ITokenService
    {

        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly IRoleService roleService;
        private readonly ICacheService cacheService;
        public IConfiguration Configuration { get; }
        public TokenService(
            ICacheService cacheService,
            IUnitOfWork<AppDbContext> unitOfWork,
            IRoleService roleService,
            IConfiguration configuration
        )
        {
            this.cacheService = cacheService;
            this.unitOfWork = unitOfWork;
            this.roleService = roleService;
            Configuration = configuration;
        }

       
        public CacheModel CreateTokenAll(User user, string roleName, Guid roleId)
        {
            var token = CreateToken(user, roleName);
            var refreshToken = GenerateToken();
            CacheModel cache = new CacheModel
            {
                Token = token,
                UserId = user.Id,
                UserName = user.UserName,
                RefreshToken = refreshToken,
                PhoneNumber = user.PhoneNumber,
                Role = roleName,
                RoleId = roleId,
                Email = user.Email,
            };

            cacheService.RemoveUser(user.Id);

            cacheService.SetUser(user.Id.ToString(), cache);

            try
            {
                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't add cache");
            }
            

            return cache;
        }

        private string CreateToken(User user, string role)
        {

            IdentityOptions _options = new IdentityOptions();
            var HashingKey = Configuration["Keys:HashingKey"];
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                new Claim("Id",user.Id.ToString()),
                                new Claim(_options.ClaimsIdentity.RoleClaimType,role),
                                new Claim("Role",role)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(HashingKey)),
                            SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }


        private string GenerateToken(int size = 32)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
