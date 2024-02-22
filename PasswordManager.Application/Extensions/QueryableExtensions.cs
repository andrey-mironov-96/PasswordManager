using Microsoft.EntityFrameworkCore;
using PasswordManager.Common;

namespace PasswordManager.Application.Extensions;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
    {
        pageNumber = pageNumber <= 0 ? 1: pageNumber;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        Task<List<T>> taskList = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        Task<int> taskCount = query.CountAsync(cancellationToken);

        return PaginatedResult<T>.Create(await taskList, await taskCount, pageNumber, pageSize);
    }
}
