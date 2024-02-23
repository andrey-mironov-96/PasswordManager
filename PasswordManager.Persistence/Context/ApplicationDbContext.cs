using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Common;
using PasswordManager.Domain.Common.Interfaces;
using PasswordManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher) : base (options)
        {
            _domainEventDispatcher = dispatcher;
        }

        public DbSet<UserData> UserDatas => Set<UserData>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                if (_domainEventDispatcher == null) return result;

                BaseEntity[] entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                    .Select(s => s.Entity)
                    .Where(w => w.DomainEvents.Any())
                    .ToArray();

                await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
