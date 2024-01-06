using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;

namespace Application.Cities.Commands.AddCity
{
    public class AddCityCommand 
    {
        public class Request : IRequest<OperationResponse<Response>>
        {
            public LanguageProperty? Name { get; set; }
        }

        public class Response
        {
            public Guid? Id { get; set; }
            public LanguageProperty? Name { get; set;}
        }
    }

}
