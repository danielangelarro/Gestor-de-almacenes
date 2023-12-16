using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Delete;

public class DeleteProveedorCommandsHandler : IRequestHandler<DeleteProveedorCommands, ErrorOr<ProveedorResult>>
{
   private readonly IProveedorRepository _proveedorRepository;

   public DeleteProveedorCommandsHandler(IProveedorRepository proveedorRepository)
   {
       _proveedorRepository = proveedorRepository;
   }

   public async Task<ErrorOr<ProveedorResult>> Handle(DeleteProveedorCommands command, CancellationToken cancellationToken)
   {
        if (await _proveedorRepository.GetProveedorByIdAsync(command.Id) is not Proveedor proveedor)
        {
            return Errors.Proveedor.NotFound;
        }

       await _proveedorRepository.DeleteProveedorAsync(proveedor);
       
       return new ProveedorResult(proveedor);
   }
}
