using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;

namespace Application.Neighborhoods.Commands.AddNeighborhood;

public class AddNeighborhoodHandler : IRequestHandler<AddNeighborhoodCommand.Request,
OperationResponse<AddNeighborhoodCommand.Response>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;
    public AddNeighborhoodHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<AddNeighborhoodCommand.Response>> HandleAsync(
        AddNeighborhoodCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var neighborhood = new Neighborhood();
        neighborhood.Id = Guid.NewGuid();
        neighborhood.Name = LanguageProperty.Create(lang, request.Name);
        await _repository.AddAsync(neighborhood);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var ret = new AddNeighborhoodCommand.Response();
        ret.Id = neighborhood.Id;
        ret.Name = neighborhood.Name;

        return ret;
    }
}