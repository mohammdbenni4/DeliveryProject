using System.Linq.Expressions;
using Application.ShopCategories.Commands.AddShopCat;
using Domain.Models;
using Domain.ShareMethods;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Http;

namespace Application.Shops.Commands.AddShop
{
    public class AddShopCommand
    {
        public class Request : IRequest<OperationResponse<Response>>
        {
            //Create Shop
            public string? ShopName { get; set; }
            public Guid ShopCategoryId { get; set; }
            
            
            //Create Main Brunch 
            public string? BrunchName { get; set; }
            
            public Guid CityId { get; set; }
            public string? MobileNumber { get; set; }
            public string? Address { get; set; }
            
            

            public bool  PaymentImmediatly { get; set; }
            public bool  DisplayThisBrunch { get; set; }

            public IFormFile? MainImage { get; set; }
            public List<IFormFile>? ImageFiles { get; set; }
            public string Description { get; set; }
            public bool  IsFeePercentage { get; set; }
            public float FeeValue { get; set; }

        }
        public class Response
        {
            public Shop Shop { get; set; }
            
            public Brunch MainBrunch { get; set; }
            
            
            public static Expression<Func<Shop, Response>> Selector(string lang)
                => a => new()
                {
                    
                };
        }
    }
}
