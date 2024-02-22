using PasswordManager.Domain.Common;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Feature.UserDatas.Commands.CreateUserData
{
    public class UserDataCreatedEvent : BaseEvent
    {
        public UserData userData { get; }

        public UserDataCreatedEvent(UserData userData)
        {
            this.userData = userData;
        }
    }
}
