using Persistence.IRepository;
using Persistence.IRepository.IEntityRepository;
using Persistence.IRepository.IUserRepository;
using Persistence.Repository;
using Persistence.Repository.EntityRepository;
using Persistence.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using Service.Utilities.BuilderUtilities;

namespace Presentation.Config.ConfigurationService
{
    public static class ScopedRepositoryConfiguration
    {
        public static IServiceCollection AddScopedRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddSingleton(typeof(IUtilitesBuilder), typeof(UtilitesBuilder));

            return services;
        }
    }
}
