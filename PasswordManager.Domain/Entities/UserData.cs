using PasswordManager.Domain.Common;

namespace PasswordManager.Domain.Entities
{
    public class UserData : BaseAuditableEntity
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Resource { get; set; } = string.Empty;
    }
}
