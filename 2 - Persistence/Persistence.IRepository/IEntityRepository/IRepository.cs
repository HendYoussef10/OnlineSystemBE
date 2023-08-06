using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository.IEntityRepository
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        public TEntity Add(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity GetSingle(Guid pId);
        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        public bool HasAny(Expression<Func<TEntity, bool>> predicate);
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);
        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate, string UserName = "");
        public List<TEntity> GetAllWithTakeAndSkipWithOrdering(int skip, int take, Func<TEntity, string> keySelector, params Expression<Func<TEntity, object>>[] includeProperties);
        public List<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        public int Count();
    }




}
