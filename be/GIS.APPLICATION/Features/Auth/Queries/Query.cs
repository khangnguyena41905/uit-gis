using GIS.APPLICATION.Abstractions.Messages;
using GIS.DOMAIN.Dtos;

namespace GIS.APPLICATION.Features.Auth.Queries;

public record LoginQuery(string UserName, string Password) : IQuery<LoginResponse>;