using API.Model;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
      protected DbModelContext _dbModel { get; set; }

        public Repository(DbModelContext dbModel)
        {
            _dbModel = dbModel;
        }

        public void Add(T entity)
        {
            _dbModel.Add(entity);
            _dbModel.SaveChanges();
        }

        public void Add(List<T> entity)
        {
            _dbModel.Add(entity);
            _dbModel.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbModel.Remove(entity);
            _dbModel.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbModel.Entry(entity).State = EntityState.Modified;
            _dbModel.Set<T>().Update(entity);
            _dbModel.SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await _dbModel.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _dbModel.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _dbModel.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbModel.Set<T>().FindAsync(id);
        }
    }
}
