using Application.Core;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Repository;

namespace Application.Cities.Commands.AddCity
{
    public class AddCityHandler : IRequestHandler<AddCityCommand.Request, OperationResponse<AddCityCommand.Response>>
    {
        private readonly ICityRepository _elRepository;
      //  private readonly ApplicationDbContext _context;
        public AddCityHandler(ICityRepository elRepository)
        {
            _elRepository = elRepository;
           // _context = context;
        }

       

        public async Task<OperationResponse<AddCityCommand.Response>> HandleAsync(AddCityCommand.Request request,
            CancellationToken cancellationToken = new())
        {
            var ret = new AddCityCommand.Response { Id = Guid.NewGuid(), Name = request.Name };
            var city = new City { Id = (Guid)ret.Id, Name = ret.Name };

            
            await _elRepository.AddAsync(city);
            await _elRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ret;

        }
    }
}
