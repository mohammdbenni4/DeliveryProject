using Application.ShopCategories.Queries.GetAllCat;
using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elkood.Application.Core.Abstractions.Resolver;

namespace Application.ShopCategories.Commands.AddShopCat
{
    public class AddShopCatHandler : IRequestHandler<AddShopCatCommand.Request, OperationResponse<AddShopCatCommand.Response>>
    {
        private readonly IRepository _repository;
        private readonly IHttpResolverService _httpResolverService;
        public AddShopCatHandler(IRepository repository, IHttpResolverService httpResolverService)
        {
            _repository = repository;
            _httpResolverService = httpResolverService;
        }
        public async Task<OperationResponse<AddShopCatCommand.Response>> HandleAsync(AddShopCatCommand.Request request, CancellationToken cancellationToken = default)
        {
            var newsc = new ShopCategory();
            newsc.Name = request.Name;
            newsc.Id = Guid.NewGuid();

            await _repository.AddAsync(newsc);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var shop = await _repository.GetAsync(newsc.Id,
                GetAllCatQuery.Response.Selector(_httpResolverService.GetLanguageCode()));
            var ret = new AddShopCatCommand.Response();
            ret.Name = shop.Name;
            ret.Id = shop.Id;  
            return ret;

        }
    }
}
