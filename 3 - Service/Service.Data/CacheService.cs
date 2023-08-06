
using AutoMapper;
using Domain.Configration.EntitiesProperties;
using Domain.Entities;
using Infrastructure.ViewModel.VM.User;
using Persistence.IRepository;
using Service.Interface;

namespace Service.Data
{
    public class CacheService : ICacheService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork<AppDbContext> unitOfWork;


        public CacheService(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public CacheModel GetCache(string refreshToken)
        {
            var cacheRepo = unitOfWork.GetRepository<Cache>();
            var cache = cacheRepo.GetFirstOrDefault(e => e.RefreshToken!.Equals(refreshToken));

            var cacheModel = mapper.Map<CacheModel>(cache);
            return cacheModel;
        }
        public void RemoveUser(string userId)
        {
            this.unitOfWork.GetRepository<Cache>().DeleteWhere(e => e.UserId.Equals(userId));
            this.unitOfWork.SaveChanges();
        }

        public void SetUser(string userId, CacheModel model)
        {
            var value = mapper.Map<Cache>(model);
            this.unitOfWork.GetRepository<Cache>().Add(value);
        }

        public bool CheckToken(string Token)
        {
            return this.unitOfWork.GetRepository<Cache>().HasAny(e => e.Token.Equals(Token) && e.CreatedDate.AddDays(1) >= DateTime.UtcNow);
        }

    }
}
