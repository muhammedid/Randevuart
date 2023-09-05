using Core.Entities;
using Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EFRepoBase<TEntity, TContext> : IEntityRepo<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext:DbContext, new()


    {
        public bool Delete(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Deleted;  
                db.SaveChanges();
            }
            return true;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var db = new TContext())
            {
                if (filter.NotIsNull())
                    return db.Set<TEntity>().Where(filter).ToList();
                else
                return db.Set<TEntity>().ToList();

            }
        }

        public TEntity Insert(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return entity;
            }
        }
    }
}
