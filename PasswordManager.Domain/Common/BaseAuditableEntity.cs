using PasswordManager.Domain.Common.Interfaces;

namespace PasswordManager.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
