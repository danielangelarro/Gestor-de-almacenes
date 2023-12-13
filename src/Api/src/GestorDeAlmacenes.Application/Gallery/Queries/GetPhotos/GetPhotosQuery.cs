using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Gallery;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.GetPhotos;

public record GetPhotosQuery() : IRequest<ErrorOr<GalleryResultList>>;