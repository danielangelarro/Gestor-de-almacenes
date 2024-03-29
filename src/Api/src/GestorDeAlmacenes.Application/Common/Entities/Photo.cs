using System.ComponentModel.DataAnnotations;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Photo
{
    [Key]
    public Guid Id { get; set; }
    public string FileDescription { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public byte[] Contenido { get; set; } = null!;
}