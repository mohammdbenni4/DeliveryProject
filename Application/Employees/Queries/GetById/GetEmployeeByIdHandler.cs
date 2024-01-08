using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.GetById;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery.Request,OperationResponse<EmployeeDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpResolverService _httpResolverService;

    public GetEmployeeByIdHandler(IHttpResolverService httpResolverService, IUserRepository userRepository)
    {
        _httpResolverService = httpResolverService;
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<EmployeeDto>> HandleAsync(GetEmployeeByIdQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode();
        var employee = await _userRepository.TrackingQuery<Employee>()
            .Where(x=>x.Id==request.EmployeeId)
            .FirstAsync(cancellationToken);
        var employeeDto = new EmployeeDto();
        employeeDto.Id = employee.Id;
        employeeDto.Name = employee.Name.GetByLanguage(lang);
        employeeDto.MobileNumbers = employee.MobileNumbers;
        employeeDto.City = await _userRepository.TrackingQuery<City>()
            .Where(x => x.Id == employee.CityId)
            .FirstAsync(cancellationToken);
        employeeDto.Address = employee.Address.GetByLanguage(lang);
        employeeDto.UserName = employee.UserName;
        employeeDto.Documents = employee.Documents;
        employeeDto.PhotoUrl = employee.PhotoUrl;


        return employeeDto;

    }
}