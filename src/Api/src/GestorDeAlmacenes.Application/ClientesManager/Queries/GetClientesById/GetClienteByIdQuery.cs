using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Clientes;
using MediatR;

namespace GestorDeAlmacenes.Application.Clientes.Query.GetClienteById;

public record GetClienteByIdQuery(
    Guid Id
) : IRequest<ErrorOr<ClienteResult>>;