using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Http;

namespace Application.Brunches.Commands.AddBrunch;

public class AddBrunchCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public LanguageProperty? Name { get; set; }

        public bool IsMainBrunch { get; set; }
       
        public Guid CityId { get; set; }
        public string? MobileNumber { get; set; }
        public LanguageProperty? Address { get; set; }
       
        public Guid ShopId { get; set; }

        public bool  PaymentImmediatly { get; set; }
        public bool  DisplayThisBrunch { get; set; }

        public IFormFile? MainImage { get; set; }
        public List<IFormFile>? ImageUrls { get; set; }
        public LanguageProperty Description { get; set; }
        public bool  IsFeePercentage { get; set; }
        public float FeeValue { get; set; }

    }
    public class Response
    {
        
    }
}