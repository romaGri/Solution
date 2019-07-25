using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByID(int id);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetListByIDsAsync(IReadOnlyList<int> iDs);
        Task<long> GetMaxValueAsync(Expression<Func<T, long>> expression);
        Task<IReadOnlyList<int>> GetPopularEntriesAsync(int count, Expression<Func<T, int>> expression);
    }
}
