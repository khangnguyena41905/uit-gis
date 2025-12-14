using GIS.APPLICATION.Abstractions.Messages;
using GIS.APPLICATION.Commons.Helpers;
using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Entities.Users;
using GIS.DOMAIN.Repositories;

namespace GIS.APPLICATION.Features.Users.Commands;

public class UserCommandHandler: 
    ICommandHandler<CreateUserCommand, User>,
    ICommandHandler<UpdateUserCommand, User>,
    ICommandHandler<DeleteUserCommand, int>
{
    private readonly IAuthHelper _authHelper;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserCommandHandler(
        IAuthHelper authHelper,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _authHelper = authHelper;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var data = request.Data;
            var user = new User(
                name: data.Name,
                email: data.Email,
                username: data.UserName,
                password: _authHelper.HashPassword(data.Password),
                phone: data.Phone,
                positionId: data.PositionId
            );
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            
            
            var newUser = await _userRepository.FindByIdAsync(
                user.Id, 
                _ => _.Position,
                _=>_.Position.Department
                );
            newUser.UpdateCode();
            await _userRepository.UpdateAsync(newUser);
            await _unitOfWork.CommitAsync();
            

            return Result.Success<User>(user);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return Result.Failure<User>(new Error("500",ex.Message));
        }
    }

    public async Task<Result<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var data = request.Data;
        var user = await _userRepository.FindByIdAsync(request.Id);
        if (user == null)
        {
            return Result.Failure<User>(Error.NotFound);
        }
        
        user.UpdateBaseInfo(
            name: data.Name,
            email: data.Email,
            phone: data.Phone,
            positionId: data.PositionId
            );
        var updated = await _userRepository.UpdateAsync(user);
        await  _unitOfWork.CommitAsync();
        return Result.Success<User>(user);
    }

    public async Task<Result<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);
        if (user == null)
        {
            return Result.Failure<int>(Error.NotFound);
        }
        
        await _userRepository.RemoveAsync(user);
        await _unitOfWork.CommitAsync();
        return Result.Success(user.Id);
    }
}