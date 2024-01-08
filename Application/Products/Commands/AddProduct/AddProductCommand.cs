using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Products.Commands.AddProduct;

public class AddProductCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Request()
        {
        }

       
        public string? Name { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public List<ProductAddOneDto> AddOnes { get; set; } = new();
        public Guid ProductCategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile? MainImage { get; set; }
        public List<IFormFile>? ProductImages { get; set; } = new();
        public Guid BrunchId { get; set; }
    }

    public class ProductAddOneDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

   
}