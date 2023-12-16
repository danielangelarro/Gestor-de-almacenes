using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Update;

public class UpdateProveedorCommandsHandler : IRequestHandler<UpdateProveedorCommands, ErrorOr<ProveedorResult>>
{
   private readonly IProveedorRepository _proveedorRepository;

   public UpdateProveedorCommandsHandler(IProveedorRepository proveedorRepository)
   {
       _proveedorRepository = proveedorRepository;
   }

   public async Task<ErrorOr<ProveedorResult>> Handle(UpdateProveedorCommands command, CancellationToken cancellationToken)
   {
        if (await _proveedorRepository.GetProveedorByIdAsync(command.Id) is not Proveedor proveedor)
        {
            return Errors.Proveedor.NotFound;
        }

        proveedor.Nombres = command.Nombres;
        proveedor.Apellidos = command.Apellidos;
        proveedor.CI = command.CI;
        proveedor.Telefono = command.Telefono;
        proveedor.Correo = command.Correo;
        proveedor.Direccion = command.Direccion;

       await _proveedorRepository.UpdateProveedorAsync(proveedor);
       
       return new ProveedorResult(proveedor);
   }
}
