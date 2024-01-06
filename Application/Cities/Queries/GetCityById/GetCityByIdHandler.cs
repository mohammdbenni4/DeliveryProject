using Application.ShopCategories.Queries.GetCatById;
using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Cities.Queries.GetCityById;

public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery.Request,
OperationResponse<GetCityByIdQuery.Response>>
{
    private readonly IRepository _repository;

    public GetCityByIdHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetCityByIdQuery.Response>> HandleAsync(GetCityByIdQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var ret = new GetCityByIdQuery.Response();
        ret = await _repository.GetAsync(request.Id,GetCityByIdQuery.Response.Selector("ar"));
        return ret;
    }
}