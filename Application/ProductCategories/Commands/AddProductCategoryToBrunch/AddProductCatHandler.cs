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

namespace Application.ProductCategories.Commands.AddProductCategoryToBrunch;

public class AddProductCatHandler : IRequestHandler<AddProductCatCommand.Request,OperationResponse>
{
    private readonly IRepository _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpResolverService _httpResolverService;
    public AddProductCatHandler(IRepository repository,
        IWebHostEnvironment webHostEnvironment, 
        IHttpResolverService httpResolverService)
    {
        _repository = repository;
        _webHostEnvironment = webHostEnvironment;
        _httpResolverService = httpResolverService;
    }
    private string _proccessUploadPhoto(IFormFile photo)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductCategoryIcons");
        string fileName = Guid.NewGuid().ToString()+"_"+photo.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return fileName;
    }

    public async Task<OperationResponse> HandleAsync(AddProductCatCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var brunch = await _repository.TrackingQuery<Brunch>()
            .Where(b => b.Id == request.BrunchId)
            .FirstAsync(cancellationToken);
        
        
        
        var productCat = new ProductCategory();
        productCat.Name =LanguageProperty.Create(lang,request.Name);
        if (request.ImageFile is not null)
        {
            productCat.ImageUrl = _proccessUploadPhoto(request.ImageFile);
        }

        productCat.Brunch = brunch;
        productCat.BrunchId = brunch.Id;

        await _repository.AddAsync(productCat);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return OperationResponse.Success();

    }
}