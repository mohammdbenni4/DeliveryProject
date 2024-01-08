using Application.Drivers.Commands.AddDriver;
using DeliveryProjectApi.Controllers.Dash;
using Elkood.API.Swagger;
using Microsoft.AspNetCore.Http;
using Xunit;
using Xunit.Abstractions;


namespace Test;

public class DriverTests : IntegrationTest<DriversController>
{
    public DriverTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
    }
    
    
    
    [Fact]
    public async Task Add()
    {
         SetApiName(ElApiGroupNames.Dashboard);
       
         var res = await _post(nameof(DriversController.Add),
             new AddDriverCommand.Request
             {
                 Name = "test",
                 Address = "test",
                 Email = "test",
                 BirthDate = new DateOnly(2001,1,1),
                 CityId = Guid.Parse("d0ab2985-90a0-4855-a654-ded5841bffad"),
               
                 MobileNumbers = new List<string>
                 {
                     "adadad","dadad"
                 },
                 BloodType = "adadad",
                 ProfitAmount = 10,
                 ProfitIsPercentage = true,
                 TelegramId = "telegramif",
                 WorkingDays = new List<string>
                 {
                     "adada","adas"
                 },
                 PhotoFile = _uploadImage(),
                 Documents = new List<IFormFile>
                 {
                     _uploadImage()
                 }
             });
         
         Assert.True(res.IsSuccessStatusCode);
    }

 
}