using GIS.DOMAIN.Abstractions;
using MediatR;

namespace GIS.APPLICATION.Abstractions.Messages;

public interface IQueryHandler : IRequestHandler<IQuery, Result>
{
}

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}