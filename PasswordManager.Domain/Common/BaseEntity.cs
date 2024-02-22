using PasswordManager.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace PasswordManager.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        private readonly List<BaseEvent> _domaintEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domaintEvents.AsReadOnly();


        public void AddDomainEvent(BaseEvent domainEvent) => _domaintEvents.Add(domainEvent);
        public void RemoveDomainEvent(BaseEvent domainEvent) => _domaintEvents.Remove(domainEvent);
        public void ClearDomainEvents() => _domaintEvents.Clear();


    }
}
