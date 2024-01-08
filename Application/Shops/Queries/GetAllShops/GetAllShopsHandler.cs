using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Shops.Queries.GetAllShops;

public class GetAllShopsHandler :IRequestHandler<GetAllShopsQuery.Request,OperationResponse<List<Brunch>>>
{
    private readonly IRepository _repository;

    public GetAllShopsHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<Brunch>>> HandleAsync(GetAllShopsQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        List<Brunch> brunches = new List<Brunch>();
        if (request.ShopCategoryId is not null && request.CityId is not null)
        {
            brunches = await _repository.TrackingQuery<Brunch>()
                .Include(c=>c.City)
                .Include(s=>s.Shop)
                .ThenInclude(sc=>sc!.ShopCategory)
                .Where(b => b.CityId == request.CityId
                            && b.Shop!.ShopCategoryId == request.ShopCategoryId)
             
                .ToListAsync(cancellationToken);
        }
        else if (request.ShopCategoryId is not null)
        {
            brunches = await _repository.TrackingQuery<Brunch>()
                .Include(c=>c.City)
                .Include(s=>s.Shop)
                .ThenInclude(sc=>sc!.ShopCategory)
                .Where(b=>b.Shop!.ShopCategoryId == request.ShopCategoryId)
                .ToListAsync(cancellationToken);
        }
        else if (request.CityId is not null)
        {
            brunches = await _repository.TrackingQuery<Brunch>()
                .Include(c=>c.City)
                .Include(s=>s.Shop)
                .ThenInclude(sc=>sc!.ShopCategory)
                .Where(b=>b.CityId == request.CityId)
                .ToListAsync(cancellationToken);
        }
        else
        {
            brunches = await _repository.TrackingQuery<Brunch>()
                .Include(c=>c.City)
                .Include(s=>s.Shop)
                .ThenInclude(sc=>sc!.ShopCategory)
                .ToListAsync(cancellationToken);
        }

        return brunches;
    }
}