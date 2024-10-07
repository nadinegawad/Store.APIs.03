using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.G03.Core.Entites;
using Store.G03.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Repository.Repositories
{
    public class SpecificationsEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includes.Aggregate(query, (currentQuerry, includeExpression) => currentQuerry.Include(includeExpression));
            return query;
        }
    }
}