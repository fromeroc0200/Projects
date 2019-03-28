using BikeStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Data.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        #region Find Objects Section
        ProcessResult<TEntity> Get(int id);
        ProcessResult<IEnumerable<TEntity>> GetAll();
        ProcessResult<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Adding Objects Section
        ProcessResult Add(TEntity entity);
        ProcessResult AddRange(IEnumerable<TEntity> entities);
        #endregion

        #region Removing Objects Section
        ProcessResult Remove(TEntity entity);
        ProcessResult RemoveRange(IEnumerable<TEntity> entities);
        #endregion

    }
}
