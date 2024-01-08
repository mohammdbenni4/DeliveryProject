using Domain.Interfaces;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Drivers.Commands.AddDriver;

public class AddDriverHandler : IRequestHandler<AddDriverCommand.Request,OperationResponse>
{
    private readonly IRepository _repository;
    private readonly IHttpResolverService _httpResolverService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public AddDriverHandler(IHttpResolverService httpResolverService, IRepository repository, IWebHostEnvironment webHostEnvironment)
    {
        _httpResolverService = httpResolverService;
        _repository = repository;
        _webHostEnvironment = webHostEnvironment;
    }
    private string _proccessUploadPhoto(IFormFile photo)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Drivers","Photos");
        string fileName = Guid.NewGuid().ToString()+"_"+photo.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return Path.Combine("Drivers","Photos",fileName) ;
    }
    private string _proccessUploadDocument(IFormFile Doc)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Drivers","Documents");
        string fileName = Guid.NewGuid().ToString()+"_"+Doc.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            Doc.CopyTo(fileStream);
        }

        return Path.Combine("Drivers","Documents",fileName) ;
    }
    public async Task<OperationResponse> HandleAsync(AddDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var city = await _repository.TrackingQuery<City>()
            .Where(x => x.Id == request.CityId)
            .FirstAsync(cancellationToken);
        
        var driver = new Driver();
        driver.Id = Guid.NewGuid();
        driver.Name = LanguageProperty.Create(lang,request.Name);
        driver.MobileNumbers=request.MobileNumbers;
        driver.BirthDate = request.BirthDate;
        driver.Email = driver.Email;
        driver.CityId = city.Id;
        driver.City = city;
        driver.Address =LanguageProperty.Create(lang,request.Address);
        driver.WorkingDays.AddRange(request.WorkingDays);

       
       
        driver.TelegramId = request.TelegramId;
        driver.ProfitIsPercentage = request.ProfitIsPercentage;
        driver.ProfitAmount = request.ProfitAmount;
        driver.BloodType = request.BloodType;

        if (request.Documents is not null)
        {
            foreach (var doc in request.Documents)
            {
                if (doc is not null)
                {
                    driver.Documents.Add(_proccessUploadDocument(doc));
                }
            }
        }

        if (request.PhotoFile is not null)
        {
            driver.PhotoUrl = _proccessUploadPhoto(request.PhotoFile);
        }

        await _repository.AddAsync(driver);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResponse.Success();
    }
}