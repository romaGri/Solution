using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrastructure
{
    public class EFRpository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly torrentsdbContext _context;

        public EFRpository(torrentsdbContext context)
        {
            _context = context;
        }

        public Task<int> CountAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).CountAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
