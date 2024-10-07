using Store.G03.Core.Entites;
using Store.G03.Core.Reposittories.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Core
{
    public interface IUnitOfWorkcs
    {
        Task<int> CompleteAsync();
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
