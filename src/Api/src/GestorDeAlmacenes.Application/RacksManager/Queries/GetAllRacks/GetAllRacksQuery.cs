using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;

namespace GestorDeAlmacenes.Application.Racks.Query.GetAllRacks;

public record GetAllRacksQuery() : IRequest<ErrorOr<RackResultList>>;
