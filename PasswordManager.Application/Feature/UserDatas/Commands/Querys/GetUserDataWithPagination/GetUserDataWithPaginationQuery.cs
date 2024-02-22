using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PasswordManager.Application.Extensions;
using PasswordManager.Application.Repositories;
using PasswordManager.Common;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Feature.UserDatas.Commands.Querys.GetUserDataWithPagination
{
    public record GetUserDataWithPaginationQuery : IRequest<PaginatedResult<GetUserDataWithPaginationQueryDTO>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public GetUserDataWithPaginationQuery() { }

        public GetUserDataWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    internal class GetUserDataWithPaginationQueryHandler : IRequestHandler<GetUserDataWithPaginationQuery, PaginatedResult<GetUserDataWithPaginationQueryDTO>>
{
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserDataWithPaginationQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<PaginatedResult<GetUserDataWithPaginationQueryDTO>> Handle(GetUserDataWithPaginationQuery request, CancellationToken cancellationToken)
        {
           return await _unitOfWork.Repository<UserData>().Entities
                .OrderBy(e => e.CreatedAt)
                .ProjectTo<GetUserDataWithPaginationQueryDTO>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
