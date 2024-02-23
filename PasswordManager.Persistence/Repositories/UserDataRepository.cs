using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.Repositories
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly IGenericRepository<UserData> _genericRepository;

        public UserDataRepository(IGenericRepository<UserData> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Task<List<UserData>> GetUserDatasByType(string type)
        {
            return _genericRepository.Entities.Where(_ => _.Type == type).ToListAsync();
        }
    }
}
