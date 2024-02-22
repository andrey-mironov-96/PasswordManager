namespace PasswordManager.Domain.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEvent> entitiesWithEvents);
    }
}
