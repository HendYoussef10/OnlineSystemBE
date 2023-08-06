using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Data;
using Service.Data.Products;
using Service.Interface;
using Service.Interface.Products;
using System.Configuration;

namespace Presentation.Config.ConfigurationService
{
    public static class ScopedServiceConfiguration
    {
        public static IServiceCollection AddScopedService(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICacheService), typeof(CacheService));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IRoleService), typeof(RoleService));
            services.AddTransient(typeof(ITokenService), typeof(TokenService));
            services.AddTransient(typeof(IProductService), typeof(ProductService));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(ICacheProductService), typeof(CacheProductService));



            return services;
        }
    }
}
