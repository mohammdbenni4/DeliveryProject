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

    public AddCustomerHandler( IHttpResolverService httpResolverService
        , IUserRepository userRepository, ElUserManager<User> elUserManager)
    {
        _httpResolverService = httpResolverService;
        _userRepository = userRepository;
        _elUserManager = elUserManager;
    }

    public async Task<OperationResponse> HandleAsync(AddCustomerCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        if (await _elUserManager.IsEmailExistAsync<Customer>(request.Email)) 
            return DomainError.User.EmailAlreadyExist(request.Email);
        
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        
        //create the customer
        var customer = new Customer();
        customer.Id = Guid.NewGuid();
        customer.Name = LanguageProperty.Create(lang,request.Name);
        customer.CityId = request.CityId;
        customer.City =
            await _userRepository.TrackingQuery<City>()
                .Where(a => a.Id == request.CityId)
                .FirstAsync(cancellationToken);

        customer.Email = request.Email;
        customer.MobileNumber = request.MobileNumber;
        customer.BornDate = request.BornDate;
        var identityResult = await _userRepository.AddWithRole(customer, request.Password,request.RoleName);
        
       
        //create the address for this customer
        
        
        return OperationResponse.Success();
    }
}