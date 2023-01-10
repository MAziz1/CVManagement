using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CVManagement.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params string[] includes);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, int page = 1, int pageCount = 10, params string[] includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> filter);
    }
}
