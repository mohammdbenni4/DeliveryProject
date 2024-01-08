using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.AddAddressToCustomer;

public class AddAdressHandler : IRequestHandler<AddAddressCommand.Request,OperationResponse>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;
    public AddAdressHandler(IRepository repository, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse> HandleAsync(AddAddressCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var customer = await _repository.TrackingQuery<Customer>()
            .Where(c => c.Id == request.CustomerId)
            .FirstAsync(cancellationToken);
        var address = new Address();
        address.Id = Guid.NewGuid();
        address.Name = LanguageProperty.Create(lang,request.AddressName);
        address.CityId = request.AddressCityId;
        address.Street = LanguageProperty.Create(lang,request.Street);
        address.Building = LanguageProperty.Create(lang, request.Building);
        address.Floor = LanguageProperty.Create(lang, request.Floor);
        address.MoreDetails = LanguageProperty.Create(lang,request.MoreDetails);
        address.NeighborhoodId = request.NeighborhoodId;
        address.CustomerId = request.CustomerId;
        address.Customer = customer;
        
        await _repository.AddAsync(address);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        customer.Address.Add(address);
        customer.AddressIds.Add(address.Id);
        _repository.Update(customer);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResponse.Success();
    }
}