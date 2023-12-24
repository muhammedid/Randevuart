using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepo<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Update(T entity);
        bool Delete(T entity);
        T Add(T entity);
    }
}
