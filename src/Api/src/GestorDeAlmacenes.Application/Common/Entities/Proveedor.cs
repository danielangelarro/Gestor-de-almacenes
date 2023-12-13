using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Proveedor : IUser
{
   public Guid ID_Proveedor { get; set; }
   public string? Nombres { get; set; }
   public string? Apellidos { get; set; }
   public string? CI { get; set; }
   public string? Telefono { get; set; }
   public string? Correo { get; set; }
   public string? Direccion { get; set; }
}