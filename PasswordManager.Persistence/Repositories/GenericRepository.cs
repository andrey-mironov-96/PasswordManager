using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Common;
using PasswordManager.Persistence.Context;

namespace PasswordManager.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return await _dbContext.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public Task UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id)!;
            _dbContext.Entry<T>(exist).CurrentValues.SetValues(exist);
            return Task.CompletedTask;
        }
    }
}
