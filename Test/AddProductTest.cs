using Application.Cities.Commands.AddCity;
using Application.Products.Commands.AddProduct;
using DeliveryProjectApi.Controllers;
using DeliveryProjectApi.Controllers.Dash;
using Elkood.API.Swagger;
using Elkood.Domain.Core.Culture;
using Elkood.Domain.Primitives;
using Elkood.ElTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Migrations;
using Xunit;
using Xunit.Abstractions;


namespace Test;

public class AddProductTest : IntegrationTest<ShopsController>
{
    public AddProductTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
    }

    [Fact]
    public async Task Add()
    {// api/Shop/Dashboard/AddProductToBrunch
        SetApiName(ElApiGroupNames.Dashboard);
        var dto1 = new AddProductCommand.ProductAddOneDto{Name = "add1",Price = 5464};
        var dto2 = new AddProductCommand.ProductAddOneDto{Name = "add2",Price = 416540};
        var img1 = _uploadImage();
        var img2 = _uploadImage();
     
        var res = await _post(nameof(ProductsController.Add),
            new AddProductCommand.Request()
            {
                Name = "testt",
                Calories = 1231,
                Description = "ada",
                Price = 1500,
                AddOnes = new List<AddProductCommand.ProductAddOneDto>{dto1,dto2},
                IsAvailable = true,
                MainImage = _uploadImage(),
                ProductImages = new List<IFormFile>{img1,img2},
                BrunchId =Guid.Parse("6c21b106-f320-4688-97d5-5c009334c34f"),
                ProductCategoryId = Guid.Parse("967a0bbb-f1b6-4c83-a4f6-1c99b29a54f6")
                
            }.ToFormData());
        
        Assert.True(res.IsSuccessStatusCode);
    }

    [Fact]
    public async Task AddCity()
    {
        SetApiName(ElApiGroupNames.Dashboard);
        var res = await _post(nameof(CitiesController.Add),
           new AddCityCommand.Request()
        {
            Name = LanguageProperty.Create(LanguageCode.ar,"test")
        });
        Assert.True(res.IsSuccessStatusCode);
    }
}