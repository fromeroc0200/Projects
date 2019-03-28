using BikeStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BikeStores.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        
        // --Setting constructor
        public Repository(DbContext context)
        {
            this._context = context;
        }
        
        public ProcessResult<TEntity> Get(int id)
        {
            ProcessResult<TEntity> result = new ProcessResult<TEntity>();
            result.Content = _context.Set<TEntity>().Find(id);
            return result;
        }

        public ProcessResult<IEnumerable<TEntity>> GetAll()
        {
            ProcessResult<IEnumerable<TEntity>> result = new ProcessResult<IEnumerable<TEntity>>();
            result.Content = _context.Set<TEntity>().ToList();
            return result;
        }

        public ProcessResult<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            ProcessResult<IEnumerable<TEntity>> result = new ProcessResult<IEnumerable<TEntity>>();
            result.Content = _context.Set<TEntity>().Where(predicate);
            return result;
        }

        public ProcessResult Add(TEntity entity)
        {
            ProcessResult result = new ProcessResult();
            result.Content = _context.Set<TEntity>().Add(entity);
            return result;
        }

        public ProcessResult AddRange(IEnumerable<TEntity> entities)
        {
            ProcessResult result = new ProcessResult();
            _context.Set<TEntity>().AddRange(entities);
            return result;
        }

        public ProcessResult Remove(TEntity entity)
        {
            ProcessResult result = new ProcessResult();
            _context.Set<TEntity>().Remove(entity);
            return result;
        }

        public ProcessResult RemoveRange(IEnumerable<TEntity> entities)
        {
            ProcessResult result = new ProcessResult();
            _context.Set<TEntity>().RemoveRange(entities);
            return result;
        }
    }
}