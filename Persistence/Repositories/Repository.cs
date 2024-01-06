using Application.Core;
using Domain.Interfaces;
using Elkood.Domain.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository : ElRepository<Guid, IApplicationDbContext>, IRepository
    {
        public Repository(IApplicationDbContext context, IOptions<ElRepositoryOptions> options) : base(context, options)
        {
        }
    }
}
