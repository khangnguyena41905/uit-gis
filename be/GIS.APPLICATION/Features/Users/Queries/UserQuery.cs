using GIS.APPLICATION.Abstractions.Messages;
using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Entities.Users;

namespace GIS.APPLICATION.Features.Users.Queries;

public class GetPagedUsersRequest : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public record GetPagedUsersQuery(GetPagedUsersRequest Data): IQuery<PagedResult<User>>;

public record GetUserByIdQuery(int Id): IQuery<User>;