using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Http;

namespace Application.ProductCategories.Commands.AddProductCategoryToBrunch;

public class AddProductCatCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
        public Guid BrunchId { get; set; }
    }
}