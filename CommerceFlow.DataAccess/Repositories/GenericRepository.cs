using CommerceFlow.DataAccess.Context;
using CommerceFlow.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Delete(T entity)
        {
            var context = new CommerceFlowContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var context = new CommerceFlowContext();
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            var context = new CommerceFlowContext();
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            using var context = new CommerceFlowContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new CommerceFlowContext();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
