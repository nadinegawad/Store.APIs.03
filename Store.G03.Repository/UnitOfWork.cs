using Store.G03.Core;
using Store.G03.Core.Entites;
using Store.G03.Core.Reposittories.contract;
using Store.G03.Repository.Data.context;
using Store.G03.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Repository
{
    public class UnitOfWork : IUnitOfWorkcs
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(type, repository);

            }
            return _repositories[type] as IGenericRepository<TEntity, TKey>;
        }
    }
}
