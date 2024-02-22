using MediatR;

namespace PasswordManager.Domain.Common
{
    public abstract class BaseEvent : INotification
    {
        public DateTime DateOccured { get; set; } = DateTime.UtcNow;
    }
}
