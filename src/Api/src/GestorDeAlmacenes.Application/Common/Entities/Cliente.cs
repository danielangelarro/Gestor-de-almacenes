using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Cliente : IUser
{
   public Guid ID_Cliente { get; set; }
   public string? Nombres { get; set; }
   public string? Apellidos { get; set; }
   public string? CI { get; set; }
   public string? Telefono { get; set; }
   public string? Correo { get; set; }
   public string? Direccion { get; set; }
}