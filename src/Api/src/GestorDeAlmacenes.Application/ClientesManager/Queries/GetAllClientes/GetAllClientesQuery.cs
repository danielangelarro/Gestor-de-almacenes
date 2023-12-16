using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Clientes;
using MediatR;

namespace GestorDeAlmacenes.Application.Clientes.Query.GetAllClientes;

public record GetAllClientesQuery() : IRequest<ErrorOr<ClienteResultList>>;
