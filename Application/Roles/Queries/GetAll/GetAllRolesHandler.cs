using Application.Cities.Queries.GetAllCities;
using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Roles.Queries.GetAll;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery.Request
    ,OperationResponse<List<GetAllRolesQuery.Response>>>
{
    private readonly IRepository _repository;

    public GetAllRolesHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllRolesQuery.Response>>> HandleAsync(GetAllRolesQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
   =>await _repository.GetAsync(GetAllRolesQuery.Response.Selector());
}