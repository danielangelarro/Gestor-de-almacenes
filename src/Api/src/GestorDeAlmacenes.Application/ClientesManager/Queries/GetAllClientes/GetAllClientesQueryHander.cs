using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Clientes;
using MediatR;

namespace GestorDeAlmacenes.Application.Clientes.Query.GetAllClientes;

public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, ErrorOr<ClienteResultList>>
{
    private readonly IClienteRepository _repository;

    public GetAllClientesQueryHandler(IClienteRepository clienteoRepository)
    {
        _repository = clienteoRepository;
    }

    public async Task<ErrorOr<ClienteResultList>> Handle(GetAllClientesQuery query, CancellationToken cancellationToken)
    {
        return new ClienteResultList(await _repository.GetAllClientesAsync());
    }
}