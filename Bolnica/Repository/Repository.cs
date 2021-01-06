using Hospital.Context;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class Repository<T> : IRepositoryBase<T> where T : class
    {
        protected HospitalContext Context { get; set; }

        public Repository(HospitalContext repositoryContext)
        {
            this.Context = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.Context.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }
    }
}
