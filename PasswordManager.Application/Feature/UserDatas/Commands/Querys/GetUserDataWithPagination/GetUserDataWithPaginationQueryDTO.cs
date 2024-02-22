using PasswordManager.Application.Common.Mappings;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Feature.UserDatas.Commands.Querys.GetUserDataWithPagination
{
    public class GetUserDataWithPaginationQueryDTO : IMapFrom<UserData>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Resource { get; set; } = string.Empty;
    }
}
