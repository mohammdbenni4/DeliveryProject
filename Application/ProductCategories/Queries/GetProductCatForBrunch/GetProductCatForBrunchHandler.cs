using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore;


namespace Application.ProductCategories.Queries.GetProductCatForBrunch;

public class GetProductCatForBrunchHandler : IRequestHandler<GetProductCatForBrunchQuery.Request,
OperationResponse<List<GetProductCatForBrunchQuery.Response>>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;
    public GetProductCatForBrunchHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<List<GetProductCatForBrunchQuery.Response>>> HandleAsync(GetProductCatForBrunchQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode();
        var cats = await _repository.TrackingQuery<ProductCategory>()
            .Where(p => p.BrunchId == request.BrunchId)
            .ToListAsync(cancellationToken);

        var ret = new List<GetProductCatForBrunchQuery.Response>();
        foreach (var cat in cats)
        {
            var somthing = new GetProductCatForBrunchQuery.Response();
            somthing.Name = cat.Name.GetByLanguage(lang);
            somthing.CatId = cat.Id;

            ret.Add(somthing);
        }

        return ret;
    }
}