using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Query.GetProveedorById;

public class GetProveedorByIdQueryHandler : IRequestHandler<GetProveedorByIdQuery, ErrorOr<ProveedorResult>>
{
    private readonly IProveedorRepository _repository;

    public GetProveedorByIdQueryHandler(IProveedorRepository proveedorRepository)
    {
        _repository = proveedorRepository;
    }

    public async Task<ErrorOr<ProveedorResult>> Handle(GetProveedorByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetProveedorByIdAsync(query.Id) is not Proveedor proveedor)
        {
            return Errors.Proveedor.NotFound;
        }

        Proveedor? proveedoro = await _repository.GetProveedorByIdAsync(query.Id);

        return new ProveedorResult(proveedoro);
    }
}