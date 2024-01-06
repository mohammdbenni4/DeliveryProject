using Application.Core;
using Domain.Interfaces;
using Elkood.Domain.Repository;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories
{
    public class CityRepository : ElRepository<Guid, IApplicationDbContext>, ICityRepository
    {
        public CityRepository(IApplicationDbContext context, IOptions<ElRepositoryOptions> options = null) : base(context, options)
        {
        }
    }
}
