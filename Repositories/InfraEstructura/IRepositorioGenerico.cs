using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.InfraEstructura
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        //IQueryable<T> GetAll();
        //T GetById(object Id);
        //IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        //int Create(T entity);
        //bool Update(T Entity);
        //bool Delete(Object id);
        //bool Save();


        //Metodos CRUD Genericos
        void Add(TEntity obj);
        TEntity GetById(int Id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }


}
