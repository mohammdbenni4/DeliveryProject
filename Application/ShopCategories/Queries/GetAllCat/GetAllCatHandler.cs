using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elkood.Application.Core.Abstractions.Resolver;

namespace Application.ShopCategories.Queries.GetAllCat
{
    public class GetAllCatHandler : IRequestHandler<GetAllCatQuery.Request, OperationResponse<GetAllCatQuery.Response>>
    {
        private readonly IRepository _repsitory;
        private readonly IHttpResolverService _httpResolverService;
        public GetAllCatHandler(IRepository repsitory, IHttpResolverService httpResolverService)
        {
            _repsitory = repsitory;
            _httpResolverService = httpResolverService;
        }
        public async Task<OperationResponse<GetAllCatQuery.Response>> HandleAsync(GetAllCatQuery.Request request, CancellationToken cancellationToken = default)
        {
            var cats = await _repsitory.GetAsync(new GetAllCatsSpecification(request)
                ,GetAllCatQuery.Response.Selector(_httpResolverService.GetLanguageCode()));
            var ret = new GetAllCatQuery.Response();
            ret.ShopCategories = cats;
            return ret;
            
        }
    }
}
