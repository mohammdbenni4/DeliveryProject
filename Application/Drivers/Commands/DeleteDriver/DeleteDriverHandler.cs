using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Drivers.Commands.DeleteDriver;

public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand.Request,OperationResponse>
{
    private readonly IRepository _repository;

    public DeleteDriverHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
         var drivers = await _repository
            .TrackingQuery<Driver>()
            .Where(u => request.Ids.Contains(u.Id))
            .ToListAsync(cancellationToken);

           _repository.SoftDelete(drivers);
           await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
           
           return OperationResponse.Success();
    }
}