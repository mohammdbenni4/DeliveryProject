using Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Elkood.Identity.EntityFramework.InfraExtensions;

namespace Application.Cities.Queries.GetAllCities
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery.Request, OperationResponse<GetAllCitiesQuery.Response>>
    {
        private readonly IRepository _repository;
        private readonly IHttpResolverService _httpResolverService;
        public GetAllCitiesHandler(IRepository repository, IHttpResolverService httpResolverService)
        {
            _repository = repository;
            _httpResolverService = httpResolverService;
        }

        public async Task<OperationResponse<GetAllCitiesQuery.Response>> HandleAsync(GetAllCitiesQuery.Request request, CancellationToken cancellationToken = default)
        {
            
            var s = await _repository.GetAsync(
                new GetAllCitiesSpecification(request), 
                GetAllCitiesQuery.Response.Selector(_httpResolverService.GetLanguageCode()));
            var ret = new GetAllCitiesQuery.Response();
           
            ret.Cities = s;
            return ret;
        }
    }
}
