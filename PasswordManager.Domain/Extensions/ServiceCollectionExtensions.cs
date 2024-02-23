using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Domain.Common;
using PasswordManager.Domain.Common.Interfaces;

namespace PasswordManager.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainLayer(this IServiceCollection services)
        {
            services.AddDomainEventDispatcher();
        }

        private static void AddDomainEventDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}
