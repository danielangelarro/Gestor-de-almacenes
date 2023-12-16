using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Clientes;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Query.GetClienteById;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ErrorOr<ClienteResult>>
{
    private readonly IClienteRepository _repository;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
    {
        _repository = clienteRepository;
    }

    public async Task<ErrorOr<ClienteResult>> Handle(GetClienteByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetClienteByIdAsync(query.Id) is not Cliente cliente)
        {
            return Errors.Cliente.NotFound;
        }

        Cliente? clienteo = await _repository.GetClienteByIdAsync(query.Id);

        return new ClienteResult(clienteo);
    }
}