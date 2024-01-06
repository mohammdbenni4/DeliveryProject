using Elkood.Application.Core.Abstractions.Data;

namespace Application.Core;

public interface IApplicationDbContext : IDbContext<Guid>
{
    
}