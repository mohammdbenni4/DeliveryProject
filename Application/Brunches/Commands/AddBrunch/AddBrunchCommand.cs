using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Http;

namespace Application.Brunches.Commands.AddBrunch;

public class AddBrunchCommand
{
    public class Request : IRequest<OperationResponse<Brunch>>
    {
        public string? Name { get; set; }

        public bool IsMainBrunch { get; set; }
       
        public Guid CityId { get; set; }
        public string? MobileNumber { get; set; }
        public string? Address { get; set; }
       
        public Guid ShopId { get; set; }

        public bool  PaymentImmediatly { get; set; }
        public bool  DisplayThisBrunch { get; set; }

        public IFormFile? MainImage { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
        public string Description { get; set; }
        public bool  IsFeePercentage { get; set; }
        public float FeeValue { get; set; }

    }
   
}