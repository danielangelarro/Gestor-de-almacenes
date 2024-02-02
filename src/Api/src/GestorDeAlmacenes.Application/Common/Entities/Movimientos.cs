using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Movimientos
{
    [Key]
    public Guid ID_Movimiento { get; set; }
    public Guid ID_Producto { get; set; }
    public Guid ID_Usuario { get; set; }
    public Guid? ID_Cliente { get; set; }
    public Guid? ID_Proveedor { get; set; }
    public string? Proveedor_Name { get; set; }
    public string? Cliente_Name { get; set; }
    public string? Autorization { get; set; }
    public string? Producto_Name { get; set; }
    public string Descripcion { get; set; } = "";
    public int Cantidad { get; set; }
    public float Precio_Unidad { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Fecha_Caducidad { get; set; }

    [MaxLength(10)]
    public string Tipo { get; set; }     

    // Relaciones
    [ForeignKey("ID_Producto")]
    [JsonIgnore]
    public Producto Producto { get; set; }
    
    [ForeignKey("ID_Usuario")]
    [JsonIgnore]
    public User Usuario { get; set; }   
    
    [ForeignKey("ID_Cliente")]
    [JsonIgnore]
    public Cliente Cliente { get; set; }

    [ForeignKey("ID_Proveedor")]
    [JsonIgnore]
    public Proveedor Proveedor { get; set; }

    public ICollection<Ubicacion_Salida> Ubicaciones { get; set; }
}