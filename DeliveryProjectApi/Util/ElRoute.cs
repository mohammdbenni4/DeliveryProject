using Microsoft.AspNetCore.Mvc;
using Elkood.API.Swagger;

namespace DeliveryProjectApi.Util
{
    public class ElRoute : RouteAttribute
    {
        public ElRoute(ElApiGroupNames name) : base($"api/{name}/[controller]/[action]")
        {
            
        }
    }
}
