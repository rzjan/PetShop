using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.InfraEstructura
{
    public class RepositorioGenerico<TEntity> : IDisposable, IRepositorioGenerico<TEntity> where TEntity : class
    {
        private PetShopContext _context = new PetShopContext();
       

        //private IDbSet<TEntity> _dbSet = null;
        public void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }           
        }

        public TEntity GetById(int? Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        //public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        //{
        //    using (_context)
        //    {
        //        return _context.Set<TEntity>().FirstOrDefault(predicate);
        //    }
        //}

        public List<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            using (_context)
            {
                return (List<TEntity>)_context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            //_context.Configuration.ValidateOnSaveEnabled = false;
            _context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            
        }

    }
}
