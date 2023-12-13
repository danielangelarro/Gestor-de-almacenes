using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Gallery;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.GetPhotoUser;

public record GetByUserPhotoQuery(
    Guid UserId
) : IRequest<ErrorOr<GalleryResultList>>;