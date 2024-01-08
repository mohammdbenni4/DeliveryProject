using Application.Roles.Queries.GetAll;
using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Shops.Queries.GetShopById;

public class GetShopByIdHandler : IRequestHandler<GetShopByIdQuery.Request,OperationResponse<GetShopByIdQuery.Response>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;

    public GetShopByIdHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<GetShopByIdQuery.Response>> HandleAsync(GetShopByIdQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var brunchSlected = await _repository.TrackingQuery<Brunch>()
            .Where(a => a.Id == request.ShopId)
            .Include(a=>a.Shop)
            .ThenInclude(a=>a!.ShopCategory)
            .FirstAsync(cancellationToken);

        var brunchs = await _repository.TrackingQuery<Brunch>()
            .Where(a => a.ShopId == brunchSlected.Shop!.Id && a.Id != brunchSlected.Id)
            .ToListAsync(cancellationToken);

        var categoriesInSelectedBrunch = await _repository.TrackingQuery<ProductCategory>()
            .Where(a => a.BrunchId == brunchSlected.Id)
            .ToListAsync(cancellationToken);

        var productsInSelectedBrunch = await _repository.TrackingQuery<Product>()
            .Where(p => p.BrunchId == brunchSlected.Id)
            .ToListAsync(cancellationToken);
        var ret = new GetShopByIdQuery.Response();
        ret.BrunchSelected = brunchSlected;
        ret.Brunches = brunchs;
        ret.CategoriesInSelectedBrunch = categoriesInSelectedBrunch;
        ret.ProductsInSelectedBrunch = productsInSelectedBrunch;
        return ret;
    }
}