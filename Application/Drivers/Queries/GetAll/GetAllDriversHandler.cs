using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using Microsoft.EntityFrameworkCore;


namespace Application.Drivers.Queries.GetAll;

public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery.Request,OperationResponse<List<DriverDto>>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;

    public GetAllDriversHandler(IHttpResolverService httpResolverService, IRepository repository)
    {
        _httpResolverService = httpResolverService;
        _repository = repository;
    }

    public async Task<OperationResponse<List<DriverDto>>> HandleAsync(GetAllDriversQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode();
        var drivers = await _repository.TrackingQuery<Driver>()
           
            .ToListAsync(cancellationToken);
        var driverDtos = new List<DriverDto>();
       
        foreach (var driver in drivers)
        {
            var driverDto = new DriverDto();
            driverDto.Id = driver.Id;
            driverDto.Name = driver.Name.GetByLanguage(lang);
            driverDto.MobileNumbers = driver.MobileNumbers;
            driverDto.Email = driver.Email;
            driverDto.City = await _repository.TrackingQuery<City>()
                .Where(x => x.Id == driver.CityId)
                .FirstAsync(cancellationToken);
            driverDto.Address = driver.Address.GetByLanguage(lang);
            driverDto.WorkingDays = driver.WorkingDays;
            driverDto.TelegramId = driver.TelegramId;
            driverDto.ProfitIsPercentage = driver.ProfitIsPercentage;
            driverDto.ProfitAmount = driver.ProfitAmount;
            driverDto.BloodType = driver.BloodType;
            driverDto.Documents = driver.Documents;
            driverDto.PhotoUrl = driver.PhotoUrl;
            
            
            driverDtos.Add(driverDto);
        }
        return driverDtos;
    }
}