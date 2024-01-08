using Application.Cities.Queries.GetCityById;
using Application.ShopCategories.Queries.GetCatById;
using Domain.Interfaces;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.Core.Abstractions.Resolver;
using Elkood.Application.Helper.ExtensionMethods.String;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Application.Shops.Commands.AddShop
{
    public class AddShopHandler : IRequestHandler<AddShopCommand.Request, OperationResponse<AddShopCommand.Response>>
    {

        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpResolverService _httpResolverService;

        public AddShopHandler(IRepository repository, IWebHostEnvironment webHostEnvironment, IHttpResolverService httpResolverService)
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

            return Path.Combine("BrunchesImages",fileName);
        }

        
        public async Task<OperationResponse<AddShopCommand.Response>> HandleAsync(AddShopCommand.Request request
            , CancellationToken cancellationToken = new CancellationToken())
        {
            var shop = new Shop();
            var brunch = new Brunch();
            var shopCategory = new ShopCategory();
            var ret = new AddShopCommand.Response();

            shopCategory = await
                _repository.TrackingQuery<ShopCategory>()
                    .Where(a=>a.Id==request.ShopCategoryId)
                    .FirstAsync(cancellationToken);
                    
            shop.Id = Guid.NewGuid();
           
            var langcode = _httpResolverService.GetLanguageCode().ToEnum<LanguageCode>();
            shop.Name = LanguageProperty.Create(langcode
                , request.ShopName);
       
            shop.ShopCategoryId = request.ShopCategoryId;
            shop.ShopCategory = shopCategory;

            await _repository.AddAsync(shop);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
           
            var city = new City();
            city = await _repository.TrackingQuery<City>()
                .Where(a => a.Id == request.CityId)
                .FirstAsync(cancellationToken);

            brunch.Id = Guid.NewGuid();
           

            brunch.Name = LanguageProperty.Create(langcode,request.BrunchName);
            brunch.City = city;
            brunch.CityId = request.CityId;
            
           
            brunch.Address = LanguageProperty.Create(langcode,request.Address);
            brunch.Shop = shop;
            brunch.ShopId = shop.Id;
            
            brunch.PaymentImmediatly = request.PaymentImmediatly;
            brunch.DisplayThisBrunch = request.DisplayThisBrunch;
           
            brunch.Description = LanguageProperty.Create(langcode,request.Description);
          
            brunch.IsFeePercentage = request.IsFeePercentage;
            brunch.FeeValue = request.FeeValue;
            brunch.IsMainBrunch = true;
            brunch.MobileNumber = request.MobileNumber;

            if (request.MainImage != null)
            {
                brunch.MainImage = _proccessUploadPhoto(request.MainImage);
            }
            List<string> urls = new List<string>();
            if (request.ImageFiles.Count > 0)
            {
                foreach (var img in request.ImageFiles)
                {
                    if (img != null)
                    {
                        urls.Add(_proccessUploadPhoto(img));
                    }

                }
            }

            brunch.ImageUrls = urls;

            await _repository.AddAsync(brunch);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            ret.Shop = shop;
            ret.MainBrunch = brunch;
            
            return ret;
        }
    }
}
