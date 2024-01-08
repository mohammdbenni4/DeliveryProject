using System.Text.Json.Serialization.Metadata;
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
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Products.Commands.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand.Request,
    OperationResponse>
{
    private readonly IRepository _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpResolverService _httpResolverService;

    public AddProductHandler(IHttpResolverService httpResolverService
        , IWebHostEnvironment webHostEnvironment
        , IRepository repository)
    {
        _httpResolverService = httpResolverService;
        _webHostEnvironment = webHostEnvironment;
        _repository = repository;
    }
    private string _proccessUploadPhoto(IFormFile photo)
    {
        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
        string fileName = Guid.NewGuid().ToString()+"_"+photo.FileName;
        string filePath = Path.Combine(folder, fileName);
        using (var fileStream = new FileStream(filePath,FileMode.Create))
        {
            photo.CopyTo(fileStream);
        }

        return Path.Combine("ProductImages",fileName);
    }
        
    
    public async Task<OperationResponse> HandleAsync(AddProductCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var ss = request.AddOnes.ToList();
        var lang = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
        var productCategory = await _repository.TrackingQuery<ProductCategory>()
            .Where(p => p.Id == request.ProductCategoryId)
            .FirstAsync(cancellationToken);
        
        
        var product = new Product();
       
        product.Id = Guid.NewGuid();
        product.Name = LanguageProperty.Create(lang,request.Name);
        product.Calories = request.Calories;
        product.Price = request.Price;
        product.Description = LanguageProperty.Create(lang,request.Description);
        product.productCategoryId = request.ProductCategoryId;
        product.ProductCategory = productCategory;
        product.IsAvailable = request.IsAvailable;

        if (request.MainImage is not null)
        {
            product.MainImage = _proccessUploadPhoto(request.MainImage);
        }

        if (request.ProductImages is not null)
        {
            foreach (var img in request.ProductImages)
            {
                if (img is not null)
                    product.ProductImages!.Add(_proccessUploadPhoto(img));
            }
        }

        product.BrunchId = request.BrunchId;

        request.AddOnes.ForEach(d =>
        {
            var extra = new ProductAddOne(LanguageProperty.Create(lang,d.Name),d.Price,product.Id);
            
            product.AddProductExtra(extra);
        });

      
           await _repository.AddAsync(product);
           await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
           await _repository.AddRangeAsync(product.AddOnes.ToList());
           await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

           return OperationResponse.Success();
    }
}