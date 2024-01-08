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

namespace Application.Employees.Commands.Add;

public class AddEmloyeeHandler : IRequestHandler<AddEmployeeCommand.Request,OperationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpResolverService _httpResolverService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public AddEmloyeeHandler(IWebHostEnvironment hostEnvironment
        , IHttpResolverService httpResolverService, IUserRepository userRepository)
    {
        _webHostEnvironment = hostEnvironment;
        _httpResolverService = httpResolverService;
        _userRepository = userRepository;
    }
    
    private string _proccessUploadPhoto(IFormFile photo)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Employees","Photos");
        string fileName = Guid.NewGuid().ToString()+"_"+photo.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return Path.Combine("Employees","Photos",fileName) ;
    }
    private string _proccessUploadDocument(IFormFile Doc)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Employees","Documents");
        string fileName = Guid.NewGuid().ToString()+"_"+Doc.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            Doc.CopyTo(fileStream);
        }

        return Path.Combine("Employees","Documents",fileName) ;
    }
  

    public async Task<OperationResponse> HandleAsync(AddEmployeeCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var city = await _userRepository.TrackingQuery<City>()
            .Where(x => x.Id == request.CityId)
            .FirstAsync(cancellationToken);


        var employee = new Employee();
        employee.Id = Guid.NewGuid();
        employee.Name = LanguageProperty.Create(lang,request.Name);
        employee.MobileNumbers = request.MobileNumbers;
        employee.BirthDate = request.BirthDate;
        employee.Address = LanguageProperty.Create(lang,request.Address);
        employee.UserName = request.UserName;
        employee.City = city;
        employee.CityId = city.Id;
        if (request.Documents is not null)
        {
            foreach (var doc in request.Documents)
            {
                if (doc is not null)
                {
                    employee.Documents.Add(_proccessUploadDocument(doc));
                }
            }
        }

        if (request.PhotoUrl is not null)
        {
            employee.PhotoUrl = _proccessUploadPhoto(request.PhotoUrl);
        }

        await _userRepository.AddWithRole(employee,request.Password,"Employee");
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return OperationResponse.Success();
    }
}