using GIS.DOMAIN.Abstractions;
using MediatR;

namespace GIS.APPLICATION.Abstractions.Messages;

public interface ICommandHandler : IRequestHandler<ICommand, Result>
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}