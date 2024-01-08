using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductAddOnes.Commands.AddAddOne;

public class AddAddOneHandler :IRequestHandler<AddAddOneCommand.Request,OperationResponse>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;

    public AddAddOneHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public AddAddOneHandler()
    {
       
    }

    public async Task<OperationResponse> HandleAsync(AddAddOneCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var product = await _repository.TrackingQuery<Product>()
            .Where(p => p.Id == request.ProductId)
            .FirstAsync(cancellationToken);
        var add = new ProductAddOne(LanguageProperty.Create(lang,request.Name),request.price
        ,product.Id);
       
        
      
        
       

        await _repository.AddAsync(add);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        _repository.Update(product);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return OperationResponse.Success();
    }
}