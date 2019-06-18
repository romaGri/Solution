using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ifrastructure
{
    public  class  SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            var count = query.CountAsync(); 

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
                var countCreteria = query.CountAsync();
            }
            if (spec.isPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            return query;
        }
    }
}