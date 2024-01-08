using Application.Core;
using Discord;
using Domain.Dtos.Users;
using Elkood;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Domain.Core.Culture;
using Elkood.ElTest.Core;
using Elkood.ElTest.Helpers;
using Elkood.ElTest.Options;
using Xunit.Abstractions;

namespace Test;

public class IntegrationTest<TController>:ElIntegrationTest<Startup, IApplicationDbContext,Guid> where TController : ElApiController
{
    private ElApiGroupNames _apiElanGroupNames;
    private readonly string _controllerName;
    public IntegrationTest(ITestOutputHelper testOutputHelper):
        base(options =>
        {
            options.SetEnvironment(Environments.Development);
            options.SetTimeOut(10);
        }, testOutputHelper)
    {
        SetLang(LanguageCode.en);
        TestClient.DefaultRequestHeaders.Add("DebugMode",true.ToString());
        _controllerName = typeof(TController).Name.GetControllerName();
        ElPathManager.ImagePath("elkood.jpg");
    }

 
    public void SetApiName(ElApiGroupNames name) => _apiElanGroupNames = name;
    public void SetLang(LanguageCode lang)
    {
        TestClient.DefaultRequestHeaders.Remove(nameof(lang));
        TestClient.DefaultRequestHeaders.Add(nameof(lang),lang.ToString());
    }
    protected override string _endpoint(string endpoint)
    {
        return $"api/{_apiElanGroupNames.ToString()}/{_controllerName}/{endpoint}";
    }

}