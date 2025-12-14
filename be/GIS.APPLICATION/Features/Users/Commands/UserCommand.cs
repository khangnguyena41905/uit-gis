using GIS.APPLICATION.Abstractions.Messages;
using GIS.DOMAIN.Entities.Users;

namespace GIS.APPLICATION.Features.Users.Commands;

// Request Model
public class UserBaseInfoRequestModel
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string PositionId { get; set; }
}

public class CreateRequestModel : UserBaseInfoRequestModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

// Commands
public record CreateUserCommand(CreateRequestModel Data) : ICommand<User>;

public record UpdateUserCommand(int Id, UserBaseInfoRequestModel Data) : ICommand<User>;

public record DeleteUserCommand(int Id) : ICommand<int>;