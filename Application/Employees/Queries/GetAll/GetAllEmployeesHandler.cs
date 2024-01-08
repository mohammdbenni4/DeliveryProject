using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.GetAll;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery.Request,
    OperationResponse<List<EmployeeDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpResolverService _httpResolverService;

    public GetAllEmployeesHandler(IHttpResolverService httpResolverService, IUserRepository userRepository)
    {
        _httpResolverService = httpResolverService;
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<List<EmployeeDto>>> HandleAsync(GetAllEmployeesQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode();
        var employees = await _userRepository.TrackingQuery<Employee>()
            .ToListAsync(cancellationToken);


        var employeeDtos = new List<EmployeeDto>();
        foreach (var employee in employees)
        {
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
            
            
            
            employeeDtos.Add(employeeDto);
        }

        return employeeDtos;

    }
}