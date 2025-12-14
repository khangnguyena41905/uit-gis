using GIS.APPLICATION.Abstractions.Messages;
using GIS.APPLICATION.Commons.Helpers;
using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Dtos;
using GIS.DOMAIN.Repositories;

namespace GIS.APPLICATION.Features.Auth.Queries;

public class QueryHandler : IQueryHandler<LoginQuery, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthHelper _authHelper;
    public QueryHandler(
        IUserRepository userRepository,
        IAuthHelper authHelper
        )
    {
        _userRepository = userRepository;
        _authHelper = authHelper;
    }
    
    public async Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindSingleAsync(u => u.UserName == request.UserName
        );

        if (user == null)
        {
            return Result.Failure<LoginResponse>(Error.NotFound);
        }
        
        if (!user.IsActive)
        {
            return Result.Failure<LoginResponse>(new Error("400", "The user is not active"));
        }
        
        if(!_authHelper.VerifyPassword(request.Password, user.Password))
        {
            return Result.Failure<LoginResponse>(new Error("400", "Password invalid"));
        }
        
        var (token, experied) = _authHelper.GenerateJwtToken(user.Id,user.UserName);
        var response = new LoginResponse()
        {
            TokenType= "Bearer",
            Token = token,
            Email = user.Email,
            ExpiresIn = experied,
            Name = user.Name,
            UserName = user.UserName
        };
        return Result.Success<LoginResponse>(response);
    }
    
}