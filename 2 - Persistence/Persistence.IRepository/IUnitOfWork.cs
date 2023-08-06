
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.IRepository.IEntityRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        long SaveChanges();
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityBase;
    }
}
