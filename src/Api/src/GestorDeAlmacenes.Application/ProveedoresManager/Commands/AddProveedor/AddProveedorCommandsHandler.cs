using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Add;

public class AddProveedorCommandsHandler : IRequestHandler<AddProveedorCommands, ErrorOr<ProveedorResult>>
{
   private readonly IProveedorRepository _proveedorRepository;

   public AddProveedorCommandsHandler(IProveedorRepository proveedorRepository)
   {
       _proveedorRepository = proveedorRepository;
   }

   public async Task<ErrorOr<ProveedorResult>> Handle(AddProveedorCommands command, CancellationToken cancellationToken)
   {
       var proveedor = new Proveedor
       {
            ID_Proveedor = Guid.NewGuid(),
            Nombres = command.Nombres,
            Apellidos = command.Apellidos,
            CI = command.CI,
            Telefono = command.Telefono,
            Correo = command.Correo,
            Direccion = command.Direccion
       };

       await _proveedorRepository.AddProveedorAsync(proveedor);
       
       return new ProveedorResult(proveedor);
   }
}
