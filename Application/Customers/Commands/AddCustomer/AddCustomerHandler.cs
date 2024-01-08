using Domain.Error;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Security;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.AddCustomer;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand.Request,OperationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpResolverService _httpResolverService;
    private readonly ElUserManager<User> _elUserManager;
    private readonly IRepository _repository;

    public AddCustomerHandler( IHttpResolverService httpResolverService
        , IUserRepository userRepository, ElUserManager<User> elUserManager, IRepository repository)
    {
        _httpResolverService = httpResolverService;
        _userRepository = userRepository;
        _elUserManager = elUserManager;
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(AddCustomerCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        if (await _elUserManager.IsEmailExistAsync<Customer>(request.Email)) 
            return DomainError.User.EmailAlreadyExist(request.Email);
        
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        
        //create the customer
        var customer = new Customer();
        customer.Id = Guid.NewGuid();
        customer.Name = LanguageProperty.Create(lang,request.CustomerName);
        customer.CityId = request.CityIdCustomer;
        customer.City =
            await _userRepository.TrackingQuery<City>()
                .Where(a => a.Id == request.CityIdCustomer)
                .FirstAsync(cancellationToken);

        customer.Email = request.Email;
        customer.MobileNumber = request.MobileNumber;
        customer.BirthDate = request.BornDate;
        customer.BornDate = request.BornDate;
        var identityResult = await _userRepository.AddWithRole(customer, request.Password,"Customer");

       
        //create the address for this customer
        var address = new Address();
        address.Id = Guid.NewGuid();
        address.Name = LanguageProperty.Create(lang,request.AddressName);
        address.CityId = request.AddressCityId;
        address.Street = LanguageProperty.Create(lang,request.Street);
        address.Building = LanguageProperty.Create(lang, request.Building);
        address.Floor = LanguageProperty.Create(lang, request.Floor);
        address.MoreDetails = LanguageProperty.Create(lang,request.MoreDetails);
        address.NeighborhoodId = request.NeighborhoodId;
        address.Customer = customer;
        address.CustomerId = customer.Id;

        await _repository.AddAsync(address);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        
        customer.Address.Add(address);
        customer.AddressIds.Add(address.Id);
        _repository.Update(customer);
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResponse.Success();
    }
}