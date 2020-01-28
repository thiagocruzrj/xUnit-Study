using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Feature.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Seach(Expression<Func<TEntity, bool>> predicate);
        int Commit();
    }
}
