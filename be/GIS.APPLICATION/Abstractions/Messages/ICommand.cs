using GIS.DOMAIN.Abstractions;
using MediatR;

namespace GIS.APPLICATION.Abstractions.Messages;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}