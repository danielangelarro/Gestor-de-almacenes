using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IPhotoRepository
{
    Task<List<Photo>> GetPhotos();
    Task<Photo?> GetPhotoById(Guid id);

    void Add(Photo photo);
    void Put(Photo photo);
    void Delete(Photo photo);
}