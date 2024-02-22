using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Repositories
{
    public interface IUserDataRepository
    {
        Task<List<UserData>> GetUserDatasByType(string type);
    }
}
