using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.OperationResponses;
using Microsoft.EntityFrameworkCore;

namespace Application.Drivers.Queries.GetById;

public class GetDriverByIdHandler :IRequestHandler<GetDriverByIdQuery.Request,OperationResponse<DriverDto>>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;

    public GetDriverByIdHandler(IHttpResolverService httpResolverService, IRepository repository)
    {
        _httpResolverService = httpResolverService;
        _repository = repository;
    }

    public async Task<OperationResponse<DriverDto>> HandleAsync(GetDriverByIdQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode();
        var driver = await _repository.TrackingQuery<Driver>()
            .Where(x => x.Id == request.DriverId)
            .FirstAsync(cancellationToken);

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


        return driverDto;
    }
}