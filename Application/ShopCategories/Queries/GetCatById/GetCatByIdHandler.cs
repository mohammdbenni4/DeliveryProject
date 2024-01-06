using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;

namespace Application.ShopCategories.Queries.GetCatById;

public class GetCatByIdHandler : IRequestHandler<GetCatByIdQuery.Request,
OperationResponse<GetCatByIdQuery.Response>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;

    public GetCatByIdHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<GetCatByIdQuery.Response>> HandleAsync(GetCatByIdQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var ret = new GetCatByIdQuery.Response();
        ret = await _repository.GetAsync(request.Id,
            GetCatByIdQuery.Response.Selector(_httpResolverService.GetLanguageCode()));

        return ret;
    }
}