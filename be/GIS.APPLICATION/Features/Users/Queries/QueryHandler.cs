using GIS.APPLICATION.Abstractions.Messages;
using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Entities.Users;
using GIS.DOMAIN.Repositories;

namespace GIS.APPLICATION.Features.Users.Queries;

public class UserQueryHandler: 
    IQueryHandler<GetPagedUsersQuery, PagedResult<User>>,
    IQueryHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;
    public UserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;   
    }
    
    public async Task<Result<PagedResult<User>>> Handle(GetPagedUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.FindAllPagedAsync(
            pageIndex: request.Data.PageIndex,
            pageSize: request.Data.PageSize,
            predicate: _ => request.Data.SearchStr == null
                            || _.UserName == request.Data.SearchStr
                            || _.Email == request.Data.SearchStr
                            || _.Name == request.Data.SearchStr
                            || _.Phone == request.Data.SearchStr
        );
    }

    public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.FindByIdAsync(request.Id);
    }
}