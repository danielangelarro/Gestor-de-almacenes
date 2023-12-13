using GestorDeAlmacenes.Application.Entities;
namespace GestorDeAlmacenes.Application.DTO.Gallery;

public record GalleryResultList(ICollection<Photo> photo);