using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using MediatR;

namespace GestorDeAlmacenes.Application.Proveedors.Query.GetAllProveedors;

public class GetAllProveedorsQueryHandler : IRequestHandler<GetAllProveedorsQuery, ErrorOr<ProveedorResultList>>
{
    private readonly IProveedorRepository _repository;

    public GetAllProveedorsQueryHandler(IProveedorRepository proveedoroRepository)
    {
        _repository = proveedoroRepository;
    }

    public async Task<ErrorOr<ProveedorResultList>> Handle(GetAllProveedorsQuery query, CancellationToken cancellationToken)
    {
        return new ProveedorResultList(await _repository.GetAllProveedoresAsync());
    }
}