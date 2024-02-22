using FluentValidation;

namespace PasswordManager.Application.Feature.UserDatas.Commands.Querys.GetUserDataWithPagination
{
    public class GetUserDataWithPaginationQueryValidator : AbstractValidator<GetUserDataWithPaginationQuery>
    {
        public GetUserDataWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number at least greater that or equal to 1");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(5)
                .WithMessage("Page size at least greater that or equal to 5");
        }
    }
}
