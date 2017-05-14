using ShipwayBusiness.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShipwayBusiness.Repository
{
    public class ShipwayRepository<T> where T:class
    {
        internal ShipwayContext Context;
        internal DbSet<T> DbSet;

        public ShipwayRepository(ShipwayContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable();
        }
        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual IEnumerable<T> ExecuteSqlCommand(string command, params object[] parameters)
        {
            return DbSet.SqlQuery(command, parameters);
        }

        public virtual IEnumerable<T> GetPagination(Expression<Func<T, bool>> expression, out int totalItem, int currentPage = 0, int pageSize = 50)
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(Expression<Func<T, bool>> expression)
        {
            return DbSet.Count(expression) > 0;
        }

        public virtual T Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public virtual T Add(T entity)
        {
            try
            {
                DbSet.Add(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                var entry = Context.Entry(entity);
                entry.State = EntityState.Deleted;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.Handle(ex);
                return false;
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                var entry = Context.Entry(entity);
                DbSet.Attach(entity);
                entry.State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.Handle(ex);
                return null;
            }
        }

        public virtual int Count(Expression<Func<T, bool>> expression)
        {
            return DbSet.Count(expression);
        }

    }
}