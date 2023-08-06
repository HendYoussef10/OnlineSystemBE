
using Persistence.Repository.EntityRepository;
using System.Reflection;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.IRepository.IEntityRepository;
using Domain.Entities.Base;
using Persistence.IRepository;
using System.Data.SqlClient;

namespace Persistence.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(T context)
        {
            this._context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityBase
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(_context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public long SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (((SqlException)ex.InnerException).Number == 2627)//dublicate Key
                {
                    throw new Exception("dublicate Key");
                }
                else if (((SqlException)ex.InnerException).Number == 547)//// Foreign Key violation
                {
                  
                    throw new Exception("Foreign Key violation");
                }

                else if (((SqlException)ex.InnerException).Number == 2601)//// Primary key violation
                {
                    throw new Exception("Primary key violation");
                }
            }
            throw new Exception("This Item Is Not Saved");
        }


    }

}
