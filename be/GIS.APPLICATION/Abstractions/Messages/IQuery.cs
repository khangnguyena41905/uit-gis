using GIS.DOMAIN.Abstractions;
using MediatR;

namespace GIS.APPLICATION.Abstractions.Messages;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}