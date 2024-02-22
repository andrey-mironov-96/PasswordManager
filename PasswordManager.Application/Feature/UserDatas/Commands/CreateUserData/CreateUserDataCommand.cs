using MediatR;
using PasswordManager.Common;
using PasswordManager.Domain.Entities;
using PasswordManager.Application.Common.Mappings;
using AutoMapper;
using PasswordManager.Application.Repositories;

namespace PasswordManager.Application.Feature.UserDatas.Commands.CreateUserData
{
    public record CreateUserDataCommand: IRequest<Result<int>>, IMapFrom<UserData>
    {
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Resource { get; set; } = string.Empty;


    }

    internal class CreateUserDataCommandHandler : IRequestHandler<CreateUserDataCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserDataCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateUserDataCommand request, CancellationToken cancellationToken)
        {
            UserData userData = new()
            {
                Login = request.Login,
                Password = request.Password,
                Type = request.Type,
                Resource = request.Resource
            };
            await _unitOfWork.Repository<UserData>().AddAsync(userData);
            userData.AddDomainEvent(new UserDataCreatedEvent(userData));
            await _unitOfWork.SaveAsync(cancellationToken);
            return await Result<int>.SuccessAsync(userData.Id, "Success creating user data");
        }
    }
}
