using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Repositories;
using PasswordManager.Persistence.Context;
using PasswordManager.Persistence.Repositories;

namespace PasswordManager.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddDbContext();
            services.AddRepositories();
        }

        private static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(conf =>
            {
                conf.UseSqlite("Data Source=passwordmanager.db", x =>
                {
                    x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork),typeof(UnitOfWork));
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddTransient<IUserDataRepository, UserDataRepository>();
        }
    }
}
