using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Common;
using PasswordManager.Persistence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private Hashtable? _repositories;
        private bool disposed;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
        {
            _repositories ??= new Hashtable();

            string type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                
                try
                {
                    Type repositoryType = typeof(GenericRepository<>);
                    Type genericRepoType = repositoryType.MakeGenericType(typeof(T));
                    object? repositoryInstance = Activator.CreateInstance(genericRepoType, _dbContext);
                    _repositories.Add(type, repositoryInstance);
                }
                catch (Exception e)
                {

                    throw;
                }
               
            }
            return (IGenericRepository<T>)_repositories[type]!;
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(e => e.Reload());
            return Task.CompletedTask;
        }

        public Task<int> SaveAndRemoveCacheAsync(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
          return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    // dispose managed resourses
                    _dbContext.Dispose();
                }
            }

            // disposed unmanaged resourses
            disposed = true;
        }
    }
}
