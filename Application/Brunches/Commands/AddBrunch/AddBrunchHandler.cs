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

namespace Application.Brunches.Commands.AddBrunch;

public class AddBrunchHandler : IRequestHandler<AddBrunchCommand.Request
    ,OperationResponse<Brunch>>
{
    private readonly IRepository _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpResolverService _httpResolverService;

    public AddBrunchHandler(IRepository repository, IWebHostEnvironment webHostEnvironment, IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _webHostEnvironment = webHostEnvironment;
        _httpResolverService = httpResolverService;
    }
    private string _proccessUploadPhoto(IFormFile photo)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "BrunchesImages");
        string fileName = Guid.NewGuid().ToString()+"_"+photo.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return Path.Combine("BrunchesImages",fileName) ;
    }
    public async Task<OperationResponse<Brunch>> HandleAsync(AddBrunchCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var city = await _repository.TrackingQuery<City>()
            .Where(c => c.Id == request.CityId)
            .FirstAsync(cancellationToken);
        var shop =await _repository.TrackingQuery<Shop>()
            .Where(c => c.Id == request.ShopId)
            .FirstAsync(cancellationToken);
        
        
        var brunch = new Brunch();
        brunch.Id = Guid.NewGuid();
        brunch.Name = LanguageProperty.Create(lang, request.Name);
        brunch.IsMainBrunch = false;
        brunch.City = city;
        brunch.CityId = city.Id;
        brunch.MobileNumber = request.MobileNumber;
        brunch.Address = LanguageProperty.Create(lang, request.Address);
        brunch.Shop = shop;
        brunch.ShopId = shop.Id;
        brunch.PaymentImmediatly = request.PaymentImmediatly;
        brunch.DisplayThisBrunch = request.DisplayThisBrunch;
        if (request.MainImage is not null)
        {
            brunch.MainImage = _proccessUploadPhoto(request.MainImage);
        }

        if (request.ImageFiles is not null && request.ImageFiles!.Count>0)
        {
            foreach (var img in request.ImageFiles)
            {
                if (img is not null)
                {
                    brunch.ImageUrls!.Add(_proccessUploadPhoto(img));
                }
            }
        }
        brunch.Description = LanguageProperty.Create(lang,request.Description);
        brunch.IsFeePercentage = request.IsFeePercentage;
        brunch.FeeValue = request.FeeValue;

        await _repository.AddAsync(brunch);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return brunch;
        
    }
}