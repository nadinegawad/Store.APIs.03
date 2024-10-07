using Store.G03.Core.Entites;
using Store.G03.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core.Reposittories.contract
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Tkey id);
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, Tkey> spec);
        Task<TEntity> GetWithSpecAsync(ISpecifications<TEntity, Tkey> spec);
        Task<int> GetCountAsync(ISpecifications<TEntity, Tkey> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
