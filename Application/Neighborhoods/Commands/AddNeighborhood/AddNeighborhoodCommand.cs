using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;

namespace Application.Neighborhoods.Commands.AddNeighborhood;

public class AddNeighborhoodCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public string Name { get; set; }
    }
    public class Response
    {
        public Guid Id { get; set; }
        public LanguageProperty Name { get; set; }
    }
}