using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace Application.Drivers.Commands.DeleteDriver;

public class DeleteDriverCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Request(Guid? id, List<Guid> ids)
        {
            if (id is not null) Ids.Add(id.Value);

            Ids.AddRange(ids);
        }

        public List<Guid> Ids { get; set; } = new();
    }
}