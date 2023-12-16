using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Query.GetRackById;

public class GetRackByIdQueryHandler : IRequestHandler<GetRackByIdQuery, ErrorOr<RackResult>>
{
    private readonly IRackRepository _repository;

    public GetRackByIdQueryHandler(IRackRepository rackRepository)
    {
        _repository = rackRepository;
    }

    public async Task<ErrorOr<RackResult>> Handle(GetRackByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetRackByIdAsync(query.Id) is not Rack rack)
        {
            return Errors.Rack.NotFound;
        }

        Rack? racko = await _repository.GetRackByIdAsync(query.Id);

        return new RackResult(racko);
    }
}