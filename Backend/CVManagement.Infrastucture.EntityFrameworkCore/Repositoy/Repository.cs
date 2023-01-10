using CVManagement.Domain;
using CVManagement.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CVManagement.Infrastucture.EntityFrameworkCore.Repositoy
{
    public class Repository<T> : IRepository<T> where T : Entity<int>
    {
        private readonly CVManagementDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(CVManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params string[] includes)
        {
            var query = BuildQuery(filter, includes);
            return await query.FirstOrDefaultAsync();

        }
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, int page = 1, int pageCount = 10, params string[] includes)
        {
            var query = BuildQuery(filter, includes);
            return await query.Skip(page - 1).Take(pageCount).ToListAsync();
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.CountAsync(filter);
        }

        private IQueryable<T> BuildQuery(Expression<Func<T, bool>> filter = null, params string[] includes)
        {
            var query = _dbSet.AsQueryable();
            if (filter != null)
                query.Where(filter);

            foreach (string include in includes)
                query = query.Include(include);

            return query;
        }
    }
}
