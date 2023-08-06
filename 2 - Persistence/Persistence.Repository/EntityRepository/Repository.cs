
using Persistence.IRepository.IEntityRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Persistence.Repository.EntityRepository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DbContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                EntityEntry dbEntityEntry = DbSet.Attach(entity);
                DbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                EntityEntry dbEntityEntry = DbSet.Attach(entity);
                dbEntityEntry.State = EntityState.Modified;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TEntity GetSingle(Guid pId)
        {
            var query = DbSet.AsQueryable();
            try
            {
                return query.Where(e => e.Id == pId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                var query = DbSet.Where(predicate);

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HasAny(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return DbSet.Where(predicate).Any();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            else
            {
                query = query.AsTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }
        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate, string UserName = "")
        {
            try
            {
                var entites = DbSet.Where(predicate);
                foreach (var entity in entites)
                {
                    DbSet.Attach(entity).State = EntityState.Deleted;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<TEntity> GetAllWithTakeAndSkipWithOrdering(int skip, int take, Func<TEntity, string> keySelector
            , params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                IQueryable<TEntity> query = DbSet;

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                var orderedQuery = query.OrderByDescending(keySelector).Skip(skip).Take(take);

                return orderedQuery.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                var query = DbSet.Where(predicate);

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Count()
        {
            try
            {
                return DbSet.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    
}

